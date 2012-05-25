using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
namespace Netron.NetronLight
{
    public abstract class ComplexShapeBase : ShapeBase, IComplexShape, IMouseListener, IHoverListener
    {
        #region Fields
        private string text = string.Empty;
        private CollectionBase<IShapeMaterial> mChildren;
        private Dictionary<Type, IInteraction> mServices;
        #endregion

        #region Properties
        [Browsable(true), Description("The text shown on the shape"), Category("Layout")]
        public virtual string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        public Dictionary<Type, IInteraction> Services
        {
            get { return mServices; }
        }
     
        #endregion

        #region Constructor
        public ComplexShapeBase() : base()
        {
            mChildren = new CollectionBase<IShapeMaterial>();
            mChildren.OnItemAdded += new EventHandler<CollectionEventArgs<IShapeMaterial>>(mChildren_OnItemAdded);
            mServices = new Dictionary<Type, IInteraction>();

        }

        public ComplexShapeBase(IModel model)
            : base(model)
        {
            mChildren = new CollectionBase<IShapeMaterial>();
            mChildren.OnItemAdded += new EventHandler<CollectionEventArgs<IShapeMaterial>>(mChildren_OnItemAdded);
            mServices = new Dictionary<Type, IInteraction>();
        }


        public override void Init()
        {
            base.Init();
            mChildren.Clear();
            mServices.Clear();
            mServices[typeof(IMouseListener)] = this;
            mServices[typeof(IHoverListener)] = this;
        }
        
        #endregion

        #region Methods

        void mChildren_OnItemAdded(object sender, CollectionEventArgs<IShapeMaterial> e)
        {
            e.Item.Shape = this;
        }

        public override void Paint(Graphics g)
        {
            base.Paint(g);
            foreach (IPaintable material in Children)
            {
                material.Paint(g);
            }
        }

        public override void Move(Point p)
        {
            base.Move(p);
            Rectangle rec;
            foreach (IShapeMaterial material in Children)
            {
                rec = material.Rectangle;

                rec.Offset(p.X, p.Y);
                material.Transform(rec);
            }
        }


        public override void Transform(int x, int y, int width, int height)
        {
            int a, b, w, h;
            foreach (IShapeMaterial material in Children)
            {

                if (material.Gliding)
                {
                    a = Convert.ToInt32(Math.Round(((double)material.Rectangle.X - (double)Rectangle.X) / (double)Rectangle.Width * width, 1) + x);
                    b = Convert.ToInt32(Math.Round(((double)material.Rectangle.Y - (double)Rectangle.Y) / (double)Rectangle.Height * height, 1) + y);
                }
                else //shift the material, do not scale the position with respect to the sizing of the shape
                {
                    a = material.Rectangle.X - Rectangle.X + x;
                    b = material.Rectangle.Y - Rectangle.Y + y;
                }
                if (material.Resizable)
                {
                    w = Convert.ToInt32(Math.Round(((double)material.Rectangle.Width) / ((double)Rectangle.Width), 1) * width);
                    h = Convert.ToInt32(Math.Round(((double)material.Rectangle.Height) / ((double)Rectangle.Height), 1) * height);
                }
                else
                {
                    w = material.Rectangle.Width;
                    h = material.Rectangle.Height;
                }

                material.Transform(new Rectangle(a,b,w,h));
            }
            base.Transform(x, y, width, height);
        }
        #endregion

        

        public virtual CollectionBase<IShapeMaterial> Children
        {
            get
            {
                return mChildren;
            }
            set
            {
                throw new InconsistencyException("You cannot set the children, use the existing collection and the clear() method.");    
            }
        }

        public override object GetService(Type serviceType)
        {
            if (Services.ContainsKey(serviceType))
                return Services[serviceType];
            else
                return null;
        }

        public void MouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            IMouseListener listener ;
            foreach (IShapeMaterial material in mChildren)
            {
                if(material.Rectangle.Contains(e.Location))
                {
                    listener = material.GetService(typeof(IMouseListener)) as IMouseListener;
                    if (listener != null) listener.MouseDown(e);
                }

            }
        }

        public void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            IMouseListener listener;
            foreach (IShapeMaterial material in mChildren)
            {
                if (material.Rectangle.Contains(e.Location))
                {
                    listener = material.GetService(typeof(IMouseListener)) as IMouseListener;
                    if (listener != null) listener.MouseMove(e);
                }
            }
        }

        public void MouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            IMouseListener listener;
            foreach (IShapeMaterial material in mChildren)
            {
                if(material.Rectangle.Contains(e.Location))
                {
                    listener = material.GetService(typeof(IMouseListener)) as IMouseListener;
                    if (listener != null) listener.MouseUp(e);
                }
            }
        }



        #region IHoverListener Members

        private IHoverListener currentHoveredMaterial = null;

        public void MouseHover(System.Windows.Forms.MouseEventArgs e)
        {
            IHoverListener listener;
            foreach(IShapeMaterial material in this.Children)
            {
                if(material.Rectangle.Contains(e.Location)) //we caught an material
                {
                    listener = material.GetService(typeof(IHoverListener)) as IHoverListener;
                    if(listener != null) //the caught material does listen
                    {
                        if(currentHoveredMaterial == listener) //it's the same as the previous time
                            listener.MouseHover(e);
                        else //we moved from one material to another listening material
                        {
                            if(currentHoveredMaterial != null) //tell the previous material we are leaving
                                currentHoveredMaterial.MouseLeave(e);
                            listener.MouseEnter(e); //tell the current one we enter
                            currentHoveredMaterial = listener;
                        }
                    }
                    else //the caught material does not listen
                    {
                        if(currentHoveredMaterial != null)
                        {
                            currentHoveredMaterial.MouseLeave(e);
                            currentHoveredMaterial = null;
                        }
                    }
                    return; //only one material at a time
                }

            }
            if(currentHoveredMaterial != null)
            {
                currentHoveredMaterial.MouseLeave(e);
                currentHoveredMaterial = null;
            }
            
        }

        public void MouseEnter(System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        public void MouseLeave(System.Windows.Forms.MouseEventArgs e)
        {
          
        }

        #endregion
    }
}
