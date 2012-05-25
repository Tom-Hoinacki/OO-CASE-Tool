using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    public class Model : IModel, IDisposable
    {
        #region Events
        public event EventHandler<EntityEventArgs> OnEntityRemoved;
        public event EventHandler<EntityEventArgs> OnEntityAdded;
        public event EventHandler<RectangleEventArgs> OnInvalidateRectangle;
        public event EventHandler OnInvalidate;
        public event EventHandler<ConnectionCollectionEventArgs> OnConnectionCollectionChanged;
        public event EventHandler<CursorEventArgs> OnCursorChange;
        protected virtual void RaiseOnConnectionCollectionChanged(ConnectionCollectionEventArgs e)
        {
            EventHandler<ConnectionCollectionEventArgs> handler = OnConnectionCollectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void RaiseOnCursorChange(Cursor cursor)
        {
            EventHandler<CursorEventArgs> handler = OnCursorChange;
            if(handler != null)
                handler(this, new CursorEventArgs(cursor));
        }

        public void RaiseOnInvalidate()
        {
            if (OnInvalidate != null)
                OnInvalidate(this, EventArgs.Empty);
        }
        public void RaiseOnInvalidateRectangle(RectangleF rectangle)
        {
            EventHandler<RectangleEventArgs> handler = OnInvalidateRectangle;
            if (handler != null)
            {
                handler(this, new RectangleEventArgs(rectangle));
            }
        }
        public event EventHandler<RectangleEventArgs> OnRectangleChanged;
        protected virtual void RaiseOnRectangleChanged(RectangleEventArgs e)
        {
            EventHandler<RectangleEventArgs> handler = OnRectangleChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<DiagramInformationEventArgs> OnDiagramInformationChanged;
        protected virtual void RaiseOnDiagramInformationChanged(DiagramInformationEventArgs e)
        {
            EventHandler<DiagramInformationEventArgs> handler = OnDiagramInformationChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        public event EventHandler<AmbienceEventArgs> OnAmbienceChanged;
        protected virtual void RaiseOnAmbienceChanged(AmbienceEventArgs e)
        {
            EventHandler<AmbienceEventArgs> handler = OnAmbienceChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void RaiseOnEntityAdded(EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void RaiseOnEntityRemoved(EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Fields
        private IPage mDefaultPage;
        private CollectionBase<IPage> mPages;
        private ShapeCollection mShapes;
        private RectangleF mRectangle;
        private DocumentInformation mInformation;
        private Ambience mAmbience;
        private CollectionBase<IDiagramEntity> mPaintables;
        private IPage mCurrentPage;

        #endregion

        #region Properties

        
        public IPage CurrentPage
        {
            get { return mCurrentPage; }
            set { mCurrentPage = value; }
        }

        public CollectionBase<IDiagramEntity> Paintables
        {
            get { return mPaintables; }
        }
        public CollectionBase<IPage> Pages
        {
            get { return mPages; }
        }
        internal IPage DefaultPage
        {
            get { return mDefaultPage; }
            set { mDefaultPage = value; }
        }
        public ShapeCollection Shapes
        {
            get
            {
                return mShapes;
            }
            internal set
            {
                mShapes = value;
            }
        }

        

        internal DocumentInformation Information
        {
            get
            {
                return mInformation;
            }
            set
            {
                mInformation = value;
            }
        }
        

    
        public Ambience Ambience
        {
            get
            {
                return mAmbience;
            }
            set
            {
                mAmbience = value;
            }
        }

        public RectangleF Rectangle
        {
            get
            {
                return mRectangle;
            }
            set
            {
                mRectangle = value;
                RaiseOnRectangleChanged(new RectangleEventArgs(value));
            }
        }

        public float X
        {
            get
            {
                return mRectangle.X;
            }            
        }

        public float Y
        {
            get
            {
                return mRectangle.Y;
            }
            
        }

        public float Width
        {
            get
            {
                return mRectangle.Width;
            }
        }

        public float Height
        {
            get
            {
                return mRectangle.Height;
            }            
        }

        public CollectionBase<IConnection> Connections
        {
            get
            {
                throw new System.NotImplementedException();
            }

        } 
        #endregion

        #region Constructor
        public Model()
        {
            mAmbience = new Ambience(this);
            //listen to events
            AttachToAmbience(mAmbience);

            //here I'll have to work on the scene graph
            this.mShapes = new ShapeCollection();

            //the page collection
            mPages = new CollectionBase<IPage>();
            
            //the default page
            mDefaultPage = new Page("Default Page");
            mDefaultPage.OnEntityAdded += new EventHandler<EntityEventArgs>(mDefaultPage_OnEntityAdded);
            mDefaultPage.OnEntityRemoved += new EventHandler<EntityEventArgs>(mDefaultPage_OnEntityRemoved);
            mDefaultPage.OnClear += new EventHandler(mDefaultPage_OnClear);
            mPages.Add(mDefaultPage);
            //initially the current page is the one and only default page
            mCurrentPage = mDefaultPage;

            //the paintables
            mPaintables = new CollectionBase<IDiagramEntity>();
        }

        #region Paintables transfers on Page changes

        void mDefaultPage_OnClear(object sender, EventArgs e)
        {
            mPaintables.Clear();
        }

        void mDefaultPage_OnEntityRemoved(object sender, EntityEventArgs e)
        {
            if(mPaintables.Contains(e.Entity))
            {
                //shift the entities above the one to be removed
                int index = e.Entity.SceneIndex;
                foreach(IDiagramEntity entity in mPaintables)
                {
                    if(entity.SceneIndex > index)
                        entity.SceneIndex--;
                }
                mPaintables.Remove(e.Entity);
            }
            //if the selection contains the shape we have to remove it from the selection
            if (Selection.SelectedItems.Contains(e.Entity))
            {
                Selection.SelectedItems.Remove(e.Entity);               
            }
            RaiseOnEntityRemoved(e);
        }

        void mDefaultPage_OnEntityAdded(object sender, EntityEventArgs e)
        {
            //don't add it if it's already there or if it's a group (unless you want to deploy something special to emphasize a group shape).
            if (!mPaintables.Contains(e.Entity) && !(e.Entity is IGroup))
            {
                //set the new entity on top of the stack
                e.Entity.SceneIndex = mPaintables.Count;
                mPaintables.Add(e.Entity);
            }
            RaiseOnEntityAdded(e);
        }
        #endregion



        #endregion

        #region Methods
        #region Ordering methods

        public void SendToBack(IDiagramEntity entity)
        {
            if(mPaintables.Contains(entity))
            {
                mPaintables.Remove(entity);
                mPaintables.Insert(0, entity);
                Rectangle rec = entity.Rectangle;
                rec.Inflate(20, 20);
                this.RaiseOnInvalidateRectangle(Rectangle);
            }
        }

        public void SendBackwards(IDiagramEntity entity, int zShift)
        {
            if (mPaintables.Contains(entity))
            {
                int newpos = mPaintables.IndexOf(entity) - zShift;
                //if this is the first in the row you cannot move it lower
                if (newpos >= 0)
                {
                    mPaintables.Remove(entity);
                    mPaintables.Insert(newpos, entity);
                    Rectangle rec = entity.Rectangle;
                    rec.Inflate(20, 20);
                    this.RaiseOnInvalidateRectangle(Rectangle);
                }

            }
        }
        public void SendBackwards(IDiagramEntity entity)
        {
            SendBackwards(entity, 1);
        }

        public void SendForwards(IDiagramEntity entity)
        {
            SendForwards(entity, 1);
        }
        public void SendForwards(IDiagramEntity entity, int zShift)
        {
            if (mPaintables.Contains(entity) && zShift>=1)
            {
                int newpos = mPaintables.IndexOf(entity) + zShift;
                //if this is the last in the row you cannot move it higher
                if (newpos < mPaintables.Count)
                {
                    mPaintables.Remove(entity);
                    mPaintables.Insert(newpos, entity); //does it works when this is an addition at the top?
                    Rectangle rec = entity.Rectangle;
                    rec.Inflate(20, 20);
                    this.RaiseOnInvalidateRectangle(Rectangle);
                }
            }
        }

        public void SendToFront(IDiagramEntity entity)
        {
            if(mPaintables.Contains(entity))
            {
                mPaintables.Remove(entity);
                mPaintables.Add(entity);
                Rectangle rec = entity.Rectangle;
                rec.Inflate(20, 20);
                this.RaiseOnInvalidateRectangle(Rectangle);
            }
        }
        #endregion

        #region Diagram manipulation actions
        public void AddShape(IShape shape)
        {
            shape.Init();
            SetModel(shape);
            //By default the new shape is added to the default in the current page
            //For now, there is only a single default page;
            DefaultPage.DefaultLayer.Entities.Add(shape);
            
        }
        public void AddConnection(IConnection connection)
        {
            SetModel(connection);
            DefaultPage.DefaultLayer.Entities.Add(connection);
        }
        
        
        public void AddConnection(IConnector from, IConnector to)
        {
            Connection con = new Connection(from.Point, to.Point);
            this.AddConnection(con);
        }

        public void SetModel(IDiagramEntity entity)
        {
            if(entity is IConnector)
            {
                (entity as IConnector).Model = this;
            }
            else if(entity is IConnection)
            {
                IConnection con = entity as IConnection;
                con.Model = this;
                Debug.Assert(con.From != null, "The 'From' connector is not set.");
                con.From.Model = this;
                Debug.Assert(con.From != null, "The 'To' connector is not set.");
                con.To.Model = this;
            }
            else if(entity is IShape)
            {
                IShape shape = entity as IShape;
                shape.Model = this;
                foreach(IConnector co in shape.Connectors)
                {
                    co.Model = this;
                }
            }
            
        }
        public void RemoveShape(IShape shape)
        {
            
            //remove it from the layer(s)
            DefaultPage.DefaultLayer.Entities.Remove(shape);
        }
        public void Remove(IDiagramEntity entity)
        {

            if (DefaultPage.DefaultLayer.Entities.Contains(entity))
            {
                entity.OnRemove();
                DefaultPage.DefaultLayer.Entities.Remove(entity);           
            }    
        }

        public void AddShape(ShapeCollection shapeCollection)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            //clear the scene-graph
            this.DefaultPage.DefaultLayer.Entities.Clear();

        }
        #endregion

        internal void AttachToAmbience(Ambience ambience)
        {
            if (ambience == null)
                throw new ArgumentNullException("The ambience object assigned to the model cannot be 'null'");

            mAmbience.OnAmbienceChanged += new EventHandler<AmbienceEventArgs>(mAmbience_OnAmbienceChanged);
        }

        void mAmbience_OnAmbienceChanged(object sender, AmbienceEventArgs e)
        {
            //pass on the good news, eventually the View will be notified and the canvas will be redrawn
            RaiseOnAmbienceChanged(e);
        }

        

     
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
                if (mAmbience != null)
                {
                    mAmbience.Dispose();
                    mAmbience = null;
                }
                #endregion
            }

        }

        #endregion
    }
}
