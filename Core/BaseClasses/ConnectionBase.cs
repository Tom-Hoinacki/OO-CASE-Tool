using System;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
	public abstract class ConnectionBase : DiagramEntityBase, IConnection
	{

		#region Fields

		private IConnector mFrom;
		private IConnector mTo;

		#endregion

		#region Properties
		public IConnector From
		{
			get{return mFrom;}
			set{mFrom = value;}
		}
		public IConnector To
		{
			get{return mTo;}
			set{mTo = value;}
		}

		#endregion

		#region Constructor
		protected ConnectionBase(IModel site) : base(site)
		{
		
		}

        protected ConnectionBase(Point from, Point to) : base()
        {
            this.mFrom = new Connector(from);
            this.mFrom.Parent = this;
            this.mTo = new Connector(to);
            this.mTo.Parent = this;
        }
        
		#endregion

        #region Methods
        public override void Paint(Graphics g)
        {
            if (g == null)
                throw new ArgumentNullException("The Graphics object is 'null'");
            From.Paint(g);
            To.Paint(g);
        }
        public override MenuItem[] ShapeMenu()
        {
            return null;
        }
        #endregion




    }
}
