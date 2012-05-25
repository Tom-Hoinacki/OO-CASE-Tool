using System;
using System.Drawing;
using System.ComponentModel;

using System.Windows.Forms;
namespace Netron.NetronLight
{
    public abstract class DiagramEntityBase : IDiagramEntity, IDisposable
    {

        #region Events
        public event EventHandler<EntityEventArgs> OnClick;
        public event EventHandler<EntityMouseEventArgs> OnMouseDown;
        public event EventHandler<EntityEventArgs> OnEntityChange;
        public event EventHandler<EntityEventArgs> OnEntitySelect;
        #endregion

        #region Fields
        private object mTag;
        private bool mHovered;
        private IModel model;
        private bool mIsSelected;
        private Pen mPen = new Pen(Color.Black, 1F);
        private string mName;
        private WeakReference mParent;
        private int mSceneIndex;
        private IGroup mGroup;

        private bool mResizable = true;
        

        #endregion

        #region Properties
        public bool Resizable
        {
            get { return mResizable; }
            set { mResizable = value; }
        }

        public abstract string EntityName { get;}
        public object Tag
        {
            get { return mTag; }
            set { mTag = value; }
        }
        public int SceneIndex
        {
            get { return mSceneIndex; }
            set { mSceneIndex = value; }
        }
        public IGroup Group
        {
            get { return mGroup; }
            set
            {
                mGroup = value;
                //propagate downwards if this is a group shape, but not if the value is 'null' since
                //the group becomes the value of the Group property
                //Note that we could have used a formal depth-traversal algorithm.
                if (this is IGroup)
                {
                    if (value == null)//occurs on an ungroup action
                    {
                        foreach (IDiagramEntity entity in (this as IGroup).Entities)
                        {
                            entity.Group = this as IGroup;
                        }
                    }
                    else //occurs when grouping
                    {
                        foreach (IDiagramEntity entity in (this as IGroup).Entities)
                        {
                            entity.Group = value;
                        }
                    }
                }

            }
        }
        public bool Hovered
        {
            get { return mHovered; }
            set
            {
                mHovered = value;
                Invalidate();
            }
        }
        public object Parent
        {
            get
            {
                if (mParent != null && mParent.IsAlive)
                {
                    return mParent.Target;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                mParent = new WeakReference(value);
            }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public abstract Rectangle Rectangle { get; }
        [Browsable(false)]
        public bool IsSelected
        {
            get { return mIsSelected; }
            set { mIsSelected = value; }
        }
        [Browsable(false)]
        public IModel Model
        {
            get { return model; }
            set { model = value; }
        }
        #endregion

        #region Constructor
        protected DiagramEntityBase(IModel model)
        {
            this.model = model;
        }
        protected DiagramEntityBase() { }
        public virtual void Init() { }
        public virtual void OnRemove() { }
        #endregion

        #region Methods
        public virtual object GetService(Type serviceType)
        {
            return null;
        }
        public abstract void Paint(Graphics g);
        public abstract bool Hit(Point p);
        public abstract void Invalidate();
        public void Invalidate(RectangleF rectangle)
        {
            if (Model != null)
                Model.RaiseOnInvalidateRectangle(rectangle);
        }
        public abstract void Move(Point p);

        public abstract MenuItem[] ShapeMenu();

        #region Raisers
        public void RaiseOnClick(EntityEventArgs e)
        {
            if (OnClick != null)
                OnClick(this, e);
        }
        public void RaiseOnMouseDown(EntityMouseEventArgs e)
        {
            if (OnMouseDown != null)
                OnMouseDown(this, e);
        }

        protected internal void RaiseOnSelect(object sender, EntityEventArgs e)
        {
            if (OnEntitySelect != null)
                OnEntitySelect(sender, e);
        }
        protected internal void RaiseOnChange(object sender, EntityEventArgs e)
        {
            if (OnEntityChange != null)
                OnEntityChange(sender, e);
        } 
        #endregion

        #endregion

        #region Standard IDispose implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);


        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                #region free managed resources


                if (mPen != null)
                {
                    mPen.Dispose();
                    mPen = null;
                }
                #endregion
            }

        }

        #endregion

    }
}
