using System;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms;
namespace Netron.NetronLight
{
    public class CustomizedObject : SmallObject
	{
		#region Fields
        DashStyle dashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        public Brush colorBrush = Brushes.WhiteSmoke;
		//Connector cBottom, cLeft, cRight, cTop; 
		#endregion

        #region Properties

        public override string EntityName
        {
            get { return "CustomizedObject"; }
        }
        #endregion

		#region Constructor

        public CustomizedObject()
            : base("CUSTOMIZED",false)
        {
            //Init(); 
        }

		public CustomizedObject(IModel s) : base(s)
		{
            //Init();
		}
        public CustomizedObject(string text)
            : base(text)
        {
            //Init();
        }

        public CustomizedObject(string text, bool shrink)
            : base(text, shrink)
        {
            //Init();
        }

        public override void Init()
         {
             base.Init();

            //init connection points
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

        public void changeRectangleStyle(DashStyle style)
        {
            dashStyle = style;
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
            g.FillRectangle(ArtPallet.ShadowBrush, Rectangle.X + 8, Rectangle.Y + 8, Rectangle.Width, Rectangle.Height);
			//the actual bundle, 

            //edit DataStoreObject Shape color here
            Brush DSShapeBrush = colorBrush;
            g.FillRectangle(DSShapeBrush, Rectangle); 

            //the edge of the bundle
            Pen DSPen = new Pen(Color.Black, 1.5F);
            
            DSPen.DashStyle =  dashStyle;
            if (Hovered || IsSelected)
            {
                DSPen.Color = selectedColor;
                DSPen.Width = selectedWidth;
                g.DrawRectangle(DSPen, Rectangle);
            }
            else
            {
                g.DrawRectangle(DSPen, Rectangle);
            }
             
            //the connectors
			for(int k=0;k<Connectors.Count;k++)
			{
				Connectors[k].Paint(g);
			}           
            
			//here we keep it really simple:
            if (!string.IsNullOrEmpty(Text))
            {
                g.DrawString(Text, DDTTextFont, DDTTextBrush, Rectangle, DDTTextFormat);
            }
            
		}
 
		#endregion	
	}
}
