using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight
{
	 class SimpleEllipse : SimpleShapeBase
	{
		#region Fields
		Connector cBottom, cLeft, cRight, cTop;
		#endregion

        #region Properties
        public override string EntityName
        {
            get { return "Simple Ellipse"; }
        }
        #endregion

		#region Constructor
		public SimpleEllipse(IModel s) : base(s)
		{
			cBottom = new Connector(new Point((int) (Rectangle.Left+Rectangle.Width/2),Rectangle.Bottom), Model);			
			cBottom.Name = "Bottom connector";
			cBottom.Parent = this;
			Connectors.Add(cBottom);

            cLeft = new Connector(new Point(Rectangle.Left, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);			
			cLeft.Name = "Left connector";
			cLeft.Parent = this;
			Connectors.Add(cLeft);

            cRight = new Connector(new Point(Rectangle.Right, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);			
			cRight.Name = "Right connector";
			cRight.Parent = this;
			Connectors.Add(cRight);

            cTop = new Connector(new Point((int)(Rectangle.Left + Rectangle.Width / 2), Rectangle.Top), Model);			
			cTop.Name = "Top connector";
			cTop.Parent = this;
			Connectors.Add(cTop);
		}

         public SimpleEllipse()
             : base()
         {
         }
		#endregion

		#region Methods
		public override bool Hit(System.Drawing.Point p)
		{
            
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(Rectangle);
            using (Region region = new Region(path))
            {
                return region.IsVisible(p);
            }
		}



		public override void Paint(System.Drawing.Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//the shadow
            g.FillEllipse(ArtPallet.ShadowBrush, Rectangle.X + 5, Rectangle.Y + 5, Rectangle.Width, Rectangle.Height);
			//the actual bundle
			g.FillEllipse(ShapeBrush,Rectangle);
			//the edge of the bundle
			if(Hovered || IsSelected)
				g.DrawEllipse(ArtPallet.HighlightPen,Rectangle);
			else
                g.DrawEllipse(ArtPallet.BlackPen, Rectangle);
			//the connectors
			for(int k=0;k<Connectors.Count;k++)
			{
				Connectors[k].Paint(g);
			}
			
			//here we keep it really simple:
			if(!string.IsNullOrEmpty(Text))
                g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, TextRectangle);
		}

	

	

		#endregion	
	}
}
