using System;
using System.Drawing;

namespace Netron.NetronLight
{
	public class Connection : ConnectionBase
	{
        #region Properties
        public override string EntityName
        {
            get { return "Default Connection"; }
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
		
		public Connection(Point mFrom, Point mTo, IModel model):base(model)
		{
			this.From = new Connector(mFrom, model);
			this.From.Name = "From";
			this.From.Parent = this;
			this.To = new Connector(mTo, model);
			this.To.Name = "To";
			this.To.Parent = this;
		}

        public Connection(Point from, Point to)
            : base(from, to)
        {
        }
		#endregion

		#region Methods

		public override void Paint(System.Drawing.Graphics g)
		{
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            base.Paint(g);
            
			if(Hovered || IsSelected)
                g.DrawLine(ArtPallet.ConnectionHighlightPen, From.Point, To.Point);
			else
				g.DrawLine(ArtPallet.ConnectionPen,From.Point,To.Point);

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
        

		#endregion

	}
}
