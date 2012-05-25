using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Netron.NetronLight
{
	public class DDTConnection : ConnectionBase, IDDTDiagramEntity 
	{
        int id=0;
        public string fromText;
        public string toText;
        public string midText;
        public int fromId;
        public int toId;
        public int fromConnectorIndex;
        public int toConnectorIndex;

        public ConnectionType connectionType = ConnectionType.NORMAL;
        #region Properties

        public override string EntityName
        {
            get { return "DDT Connection"; }
        }

     
        public override Rectangle Rectangle
        {
            get
            {
                return System.Drawing.Rectangle.FromLTRB(Math.Min(From.Point.X, To.Point.X), Math.Min(From.Point.Y, To.Point.Y), Math.Max(From.Point.X, To.Point.X), Math.Max(From.Point.Y, To.Point.Y));
            }
             //set               {                throw new InconsistencyException("The rectangle of a connection cannot be set.");            }
        }
        #endregion

		#region Constructor

        public DDTConnection(Point mFrom, Point mTo, IModel model, ConnectionType type)
            : base(model)
		{
			this.From = new Connector(mFrom, model);
			this.From.Name = "From";
			this.From.Parent = this;


			this.To = new Connector(mTo, model);
			this.To.Name = "To";
			this.To.Parent = this;


            this.connectionType = type;
            
		}

        public DDTConnection(IConnector mFrom, IConnector mTo, IModel model, ConnectionType type)
            : base(model)
        {
        
                this.From = new Connector(mFrom.Point, model);
                this.From.Name = "From";
                this.From.Parent = this;

                From.AttachTo(mFrom);
             
            
                this.To = new Connector(mTo.Point, model); ;
                this.To.Name = "To";
                this.To.Parent = this;
 
                To.AttachTo(mTo);
             

            this.connectionType = type; 
        }



        public DDTConnection(Point from, Point to)
            : base(from, to)
        {
        }

        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Tfrom
        {
            get { return fromText; }
            set { this.fromText = value; }
        }
        public string Tto
        {
            get { return toText; }
            set { this.toText = value; }
        }
        public string Tmid
        {
            get { return midText; }
            set { this.midText = value; }
        }
        public void setText(string from, string mid, string to)
        {
            this.Tfrom = from;
            this.Tto = to;
            this.Tmid = mid;
        }
		#endregion

		#region Methods

		public override void Paint(System.Drawing.Graphics g)
		{
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            base.Paint(g);

            if (Hovered || IsSelected)
            {
               
                g.DrawLine(ConnectionPenFactory.getConnection(LineType.HIGHLIGHTED, connectionType, g), From.Point, To.Point);
               //MessageBox.Show("");
            }
            else
            {
                g.DrawLine(ConnectionPenFactory.getConnection(LineType.NORMAL, connectionType, g), From.Point, To.Point);

            }
            g.DrawLine(ArtPallet.ConnectionShadow, From.Point.X + 5, From.Point.Y + 5, To.Point.X + 5, To.Point.Y + 5);
		}
		public override void Invalidate()
		{
            /* the old way
			Rectangle f = new Rectangle(From.Point,new Size(10,10));
			Rectangle t = new Rectangle(To.Point,new Size(10,10));
			this.Invalidate(Rectangle.Union(f,t));
             */
            Rectangle rec = this.Rectangle;
            rec.Inflate(50, 50);
            Invalidate(rec);
		}

		public override bool Hit(Point p)
		{
			Point p1,p2, s;
			RectangleF r1, r2;
			float o,u;
			p1 = From.Point; p2 = To.Point;
	
			// p1 must be the leftmost point.
			if (p1.X > p2.X) { s = p2; p2 = p1; p1 = s; }

			r1 = new RectangleF(p1.X, p1.Y, 0, 0);
			r2 = new RectangleF(p2.X, p2.Y, 0, 0);
			r1.Inflate(3, 3);
			r2.Inflate(3, 3);
			//this is like a topological neighborhood
			//the connection is shifted left and right
			//and the point under consideration has to be in between.						
			if (RectangleF.Union(r1, r2).Contains(p))
			{
				if (p1.Y < p2.Y) //SWNE
				{
					o = r1.Left + (((r2.Left - r1.Left) * (p.Y - r1.Bottom)) / (r2.Bottom - r1.Bottom));
					u = r1.Right + (((r2.Right - r1.Right) * (p.Y - r1.Top)) / (r2.Top - r1.Top));
					return ((p.X > o) && (p.X < u));
				}
				else //NWSE
				{
					o = r1.Left + (((r2.Left - r1.Left) * (p.Y - r1.Top)) / (r2.Top - r1.Top));
					u = r1.Right + (((r2.Right - r1.Right) * (p.Y - r1.Bottom)) / (r2.Bottom - r1.Bottom));
					return ((p.X > o) && (p.X < u));
				}
			}
			return false;
		}

		public override void Move(Point p)
		{
            if (From.AttachedTo != null || To.AttachedTo != null) return;

            Rectangle rec = this.Rectangle;
            rec.Inflate(20, 20);
            this.From.Move(p);
            this.To.Move(p);
            this.Invalidate();
            this.Invalidate(rec);
		}

        public void addConnectionText() 
        {

            if (this.Tfrom != null && !this.Tfrom.Equals(""))
            {
                ConnectionText ct = new ConnectionText(this, TextPosition.From);
                this.Model.AddShape(ct);
            }
            if (this.Tto != null && !this.Tto.Equals(""))
            {
                ConnectionText ct1 = new ConnectionText(this, TextPosition.To);
                this.Model.AddShape(ct1);
            }
            if (this.Tmid != null && !this.Tmid.Equals(""))
            {
                ConnectionText ct2 = new ConnectionText(this, TextPosition.Mid);
                this.Model.AddShape(ct2);
            }
 
        
        }
        public void OnRemove()
        {
            List<IDiagramEntity> templist = new List<IDiagramEntity>();
            foreach (IDiagramEntity temp in this.Model.Paintables)
            {
                if (temp.GetType().Equals(typeof(ConnectionText)))
                {
                    if (((ConnectionText)temp).Connection.Equals(this))
                    {
                        templist.Add(temp);
                    }
                }
            }

            foreach (IDiagramEntity i in templist)
                this.Model.Remove(i);
        
        }




        public void OnDoubleClick(MouseEventArgs e) {  }
        public void OnRightDoubleClick(MouseEventArgs e) {  }
        public void OnRightClick(MouseEventArgs e) {  }
        public string getText() { return connectionType.ToString().ToLower(); }
        public Point getLocation() { return this.Rectangle.Location; }
		#endregion

	}
}
