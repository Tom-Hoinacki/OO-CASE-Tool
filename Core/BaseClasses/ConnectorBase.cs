using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
	public abstract class ConnectorBase : DiagramEntityBase, IConnector
	{
		#region Fields
		private Point point;
        private CollectionBase<IConnector> attachedConnectors;
		private IConnector attachedTo;
		
		#endregion

		#region Properties

        public CollectionBase<IConnector> AttachedConnectors
		{
			get{return attachedConnectors;}		
		}
	

		public IConnector AttachedTo
		{		
			get{return attachedTo;}
			set{attachedTo = value;}
		}

		public Point Point
		{
			get{return point;}
			set{
                //throw new NotSupportedException("Use the Move() method instead.");

             point = value;
            //foreach(IConnector con in  attachedConnectors)
            //{
            //    con.Point = value;
            //}
            }
		}
		#endregion

		#region Constructor
        protected ConnectorBase(IModel model)
            : base(model)
		{
			attachedConnectors = new CollectionBase<IConnector>();
		}

        protected ConnectorBase(Point p, IModel model)
            : base(model)
		{
			attachedConnectors = new CollectionBase<IConnector>();
			point = p;
		}

        protected ConnectorBase(Point p) : base()
        {
            this.point = p;
        }
		#endregion

		#region Methods
        public override  MenuItem[] ShapeMenu()
        {
            return null;
        }

		public void AttachConnector(IConnector connector)
		{
            if(connector == null)
                return;
            //only attach'm if not already present and not the parent
            if(!attachedConnectors.Contains(connector) && connector!=attachedTo)
            {
                connector.DetachFromParent();
                attachedConnectors.Add(connector);
                //make sure the attached connector is centered at this connector
                connector.Point = this.point;
                connector.AttachedTo = this;
            }

		}

		public void DetachConnector(IConnector connector)
		{
            if(connector == null)
                return;

            if(attachedConnectors.Contains(connector))
            {
                attachedConnectors.Remove(connector);
                connector.AttachedTo = null;
            }
		}

        public void DetachFromParent()
        {
            if(this.AttachedTo != null)
            {
                this.AttachedTo.AttachedConnectors.Remove(this);
                this.AttachedTo = null;
            }

        }

        public void AttachTo(IConnector parent)
        {

            if(parent == null)
                return;
            //donnot re-attach and the parent cannot be an already attached child
            if(this.AttachedTo != parent && !AttachedConnectors.Contains(parent))
            {
                //remove any other binding
                DetachFromParent();
                //attach to the given parent
                parent.AttachedConnectors.Add(this);
                this.AttachedTo = parent;
            }
        }
		

		
		
		#endregion

    }
}
