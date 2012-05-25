using System;
using System.Drawing;

namespace Netron.NetronLight
{
	public class Connector : ConnectorBase
    {
        #region Properties
        public override string EntityName
        {
            get { return "Default Connector"; }
        }
        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Point.X - 2, Point.Y - 2, 4, 4);
            }
            //set {               Point = value.Location;                //TODO: think about what to do when setting the size            }
        }
        #endregion

        #region Constructor
        public Connector(IModel site):base(site){}
		public Connector(Point p, IModel site):base(p, site){}
        public Connector(Point p) : base(p)
        {
        }
		#endregion

		#region Methods
        
		public override void Paint(Graphics g)
		{
            if (g == null)
                throw new ArgumentNullException("The Graphics object is 'null'");

            Pen pen = new Pen(Color.Red, 3F);
            if (Hovered || IsSelected)
            {
                g.FillEllipse(Brushes.PeachPuff, Point.X - 5, Point.Y - 5, 10, 10);
                g.DrawEllipse(pen, Point.X - 5, Point.Y - 5, 10, 10);
            }
            else
            {
                g.FillEllipse(Brushes.Black, Point.X - 4, Point.Y - 4, 7, 7);

            } 

//			this is useful when debugging, but annoying otherwise (though you might like it)			
//			if(name!=string.Empty)
//				g.DrawString(name,new Font("verdana",10),Brushes.Black,Point.X+7,Point.Y+4);
		}

		public override bool Hit(Point p)
		{
			Point a = p;
			Point b  = Point;
			b.Offset(-7,-7);
			//a.Offset(-1,-1);
			Rectangle r = new Rectangle(a,new Size(0,0));
			Rectangle d = new Rectangle(b, new Size(15,15));
			return d.Contains(r);
		}

		public override void Invalidate()
		{
			Point p = Point;
			p.Offset(-5,-5);
            if(Model!=null)
			    Model.RaiseOnInvalidateRectangle(new Rectangle(p,new Size(10,10)));
		}

		public override void Move(Point p)
		{
            Point pt = new Point(this.Point.X + p.X, this.Point.Y + p.Y);            
            IConnection con = null;
            Point p1 = Point.Empty, p2 = Point.Empty;
            Rectangle rec = new Rectangle(Point.X - 10, Point.Y - 10, 20, 20);
            this.Point = pt;
            
            #region Case of connection
            if (typeof(IConnection).IsInstanceOfType(this.Parent))
            {
                (Parent as IConnection).Invalidate();
            }
            #endregion

            #region Case of attached connectors
            for (int k = 0; k < AttachedConnectors.Count; k++)
            {
                if (typeof(IConnection).IsInstanceOfType(AttachedConnectors[k].Parent))
                {
                    //keep a reference to the two points so we can invalidate the region afterwards
                    con = AttachedConnectors[k].Parent as IConnection;
                    p1 = con.From.Point;
                    p2 = con.To.Point;
                }
                AttachedConnectors[k].Move(p);
                if (con != null)
                {
                    //invalidate the 'before the move'-region                     
                    Rectangle f = new Rectangle(p1, new Size(10, 10));
                    Rectangle t = new Rectangle(p2, new Size(10, 10));
                    Model.RaiseOnInvalidateRectangle(Rectangle.Union(f, t));
                    //finally, invalidate the region where the connection is now
                    (AttachedConnectors[k].Parent as IConnection).Invalidate();
                }
            } 
            #endregion
            //invalidate this connector, since it's been moved
            Invalidate(rec);//before the move
            this.Invalidate();//after the move
            
		}

		public  void Move(int x, int y)
		{
			Point pt = new Point( x, y);
            Move(pt);
		}
       
	

		#endregion
	}
}
