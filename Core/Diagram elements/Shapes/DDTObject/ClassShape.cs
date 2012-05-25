using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text; 
//using System.Windows.Forms;
namespace Netron.NetronLight
{
    public class ClassShape : DDTObject
	{
		#region Fields
		//Connector cBottom, cLeft, cRight, cTop;
        string name;
        bool shrink;
        Rectangle upperRec;
        Rectangle lowerRec;



		#endregion

        #region Properties
        public override string EntityName
        {
            get { return "ClassShape"; }
        }
        #endregion

		#region Constructor

        public ClassShape()
            : base()
        {
            //Init(); 
            Text = "class shape";
            shrink = false;
        }

		public ClassShape(IModel s) : base(s)
		{
            //Init();
		}

        public ClassShape(string text)
            : base()
        {
            //Init();
            this.name = text;
            Text = name;
        }

        public ClassShape(string text, bool shrink)
            : base()
        {
            //Init();
            this.name = text;
            Text = name;
            this.shrink = shrink;

        }

        public override void Init()
         {
             setRectangleSize();
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


        private void setRectangleSize()
        {
            if (shrink)
            {
                Height = 50;
                Width = 70;
                //resest the text rectangle size
                //TextRectangle = Rectangle;
            }
            else
            {
                Height = 70;
                Width = 100;
                //resest the text rectangle size
                //TextRectangle = Rectangle;
            }
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
            int upperRecHeight = 25;
            
            int lowerRecHeight = Rectangle.Height-upperRecHeight;
            upperRec = new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, upperRecHeight);
            lowerRec = new Rectangle(Rectangle.X, Rectangle.Y + upperRecHeight, Rectangle.Width, lowerRecHeight); 

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			//the shadow
            g.FillRectangle(ArtPallet.ShadowBrush, Rectangle.X + 8, Rectangle.Y + 8, Rectangle.Width, Rectangle.Height);
			//the actual bundle, 
            //edit Class Shape color here
            Brush ClassShapeBrush = Brushes.Snow;
            g.FillRectangle(ClassShapeBrush, Rectangle);
			
            //the edge of the bundles
            Pen ClassPen = new Pen(Color.DarkOrange, 2F);
            ClassPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (Hovered || IsSelected)
            {
                ClassPen.Color = Color.DodgerBlue;
                ClassPen.Width = 3F;
                g.DrawRectangle(ClassPen, upperRec);
                g.DrawRectangle(ClassPen, lowerRec); 
            }
            else
            {
                g.DrawRectangle(ClassPen, upperRec);
                g.DrawRectangle(ClassPen, lowerRec); 
            
            }
            
            //the connectors
			for(int k=0;k<Connectors.Count;k++)
			{
				Connectors[k].Paint(g);
			}
            StringFormat ClassTextFormat = new StringFormat();
            Font ClassTextFont = new Font("Arial", 8.5F, FontStyle.Bold);
			//here we keep it really simple:
            if (!string.IsNullOrEmpty(Text))
            {
                ClassTextFormat.Alignment = StringAlignment.Center;
                ClassTextFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, ClassTextFont, Brushes.Black, upperRec, ClassTextFormat);
            }
       
		}

		#endregion	
	}
}
