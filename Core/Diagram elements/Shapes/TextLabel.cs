using System;
using System.Drawing;

namespace Netron.NetronLight
{
	 class TextLabel : SimpleShapeBase
	{
		#region Fields
		
		#endregion

        #region Properties
        public override string EntityName
        {
            get { return "Text Label"; }
        }
         #endregion

		#region Constructor
		public TextLabel(IModel s) : base(s)
		{
			this.ShapeColor = Color.Transparent;
		}
         public TextLabel()
             : base()
         { }
		#endregion

		#region Methods
		public override bool Hit(System.Drawing.Point p)
		{
			Rectangle r= new Rectangle(p, new Size(5,5));
			return Rectangle.Contains(r);			
		}

		public override void Paint(System.Drawing.Graphics g)
		{
            if(g == null)
                throw new ArgumentNullException("The Graphics object is 'null'.");

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //the shadow
            g.FillRectangle(ArtPallet.ShadowBrush, Rectangle.X + 5, Rectangle.Y + 5, Rectangle.Width, Rectangle.Height);
			//the container
			g.FillRectangle(ShapeBrush,Rectangle);
			//the edge
			if(Hovered || IsSelected)
				g.DrawRectangle(new Pen(Color.Red,2F),Rectangle);
			//the text		
			if(!string.IsNullOrEmpty(Text ))
                g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, Rectangle);
		}

	
		

	


		#endregion	
        
	}
}
