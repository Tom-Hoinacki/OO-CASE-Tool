using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight
{
	 public class SimpleRectangle : SimpleShapeBase
	{
		#region Fields
		Connector cBottom, cLeft, cRight, cTop;
		#endregion

        #region Properties
        public override string EntityName
        {
            get { return "Simple Rectangle"; }
        }
        #endregion

		#region Constructor
		public SimpleRectangle(IModel s) : base(s)
		{
            //Init();
		}
         public SimpleRectangle()
             : base()
         {
             //Init();
         }

         public override void Init()
         {
             base.Init();
             cTop = new Connector(new Point((int) (Rectangle.Left + Rectangle.Width / 2), Rectangle.Top), Model);
             cTop.Name = "Top connector";      
             cTop.Parent = this;
             Connectors.Add(cTop);

             cRight = new Connector(new Point(Rectangle.Right, (int) (Rectangle.Top + Rectangle.Height / 2)), Model);
             cRight.Name = "Right connector";
             cRight.Parent = this;
             Connectors.Add(cRight);

             cBottom = new Connector(new Point((int)(Rectangle.Left + Rectangle.Width / 2), Rectangle.Bottom), Model);
             cBottom.Name = "Bottom connector";
             cBottom.Parent = this;
             Connectors.Add(cBottom);

             cLeft = new Connector(new Point(Rectangle.Left, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);
             cLeft.Name = "Left connector";
             cLeft.Parent = this;
             Connectors.Add(cLeft);

             

            
         }
		#endregion

		#region Methods
		public override bool Hit(System.Drawing.Point p)
		{
			Rectangle r= new Rectangle(p, new Size(5,5));
			return Rectangle.Contains(r);			
		}



		public override void Paint(System.Drawing.Graphics g)
		{
            /*
            Matrix or = g.Transform;
            Matrix m = new Matrix();
            m.RotateAt(20, Rectangle.Location);            
            g.MultiplyTransform(m, MatrixOrder.Append);
             */
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//the shadow
            g.FillRectangle(ArtPallet.ShadowBrush, Rectangle.X + 5, Rectangle.Y + 5, Rectangle.Width, Rectangle.Height);
			//the actual bundle
			g.FillRectangle(ShapeBrush,Rectangle);
			//the edge of the bundle
			if(Hovered || IsSelected)
				g.DrawRectangle(ArtPallet.HighlightPen,Rectangle);
			else
                g.DrawRectangle(ArtPallet.BlackPen, Rectangle);
			//the connectors
			for(int k=0;k<Connectors.Count;k++)
			{
				Connectors[k].Paint(g);
			}
			
			//here we keep it really simple:
			if(!string.IsNullOrEmpty(Text))
                g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, TextRectangle);
            //g.Transform = or;
		}

	

		

		#endregion	
	}
}
