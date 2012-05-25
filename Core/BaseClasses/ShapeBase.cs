using System;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight
{
	public abstract class ShapeBase : DiagramEntityBase, IShape
	{
		#region Events
		
		

		#endregion

		#region Fields
		private Rectangle mRectangle;
		private Color shapeColor;
		private Brush shapeBrush;
        private CollectionBase<IConnector> connectors;
		#endregion

		#region Properties


		public Brush ShapeBrush
		{
			get{return shapeBrush;}
			set{shapeBrush = value;}
		}

        public CollectionBase<IConnector> Connectors
		{
			get{return connectors;}
			set{connectors = value;}
		}

		[Browsable(true), Description("The width of the shape"), Category("Layout")]
		public int Width
		{
			get{return this.mRectangle.Width;}
			set{Transform(this.Rectangle.X, this.Rectangle.Y, value,this.Height);}
		}

		[Browsable(true), Description("The height of the shape"), Category("Layout")]
		public int Height
		{
			get{return this.mRectangle.Height;}
            set
            {
                Transform(this.Rectangle.X, this.Rectangle.Y, this.Width, value);
            }
		}

		

		[Browsable(true), Description("The x-coordinate of the upper-left corner"), Category("Layout")]
		public int X
		{
			get{return mRectangle.X;}
			set{
				Point p = new Point(value - mRectangle.X, mRectangle.Y);
				this.Move(p);

                //if(Model!=null)
				  //  Model.RaiseOnInvalidate(); //note that 'this.Invalidate()' will not be enough
			}
		}

		[Browsable(true), Description("The y-coordinate of the upper-left corner"), Category("Layout")]
		public int Y
		{
			get{return mRectangle.Y;}
			set{
				Point p = new Point(mRectangle.X, value - mRectangle.Y);
				this.Move(p);
                //Model.RaiseOnInvalidate();
			}
		}
		[Browsable(true), Description("The backcolor of the shape"), Category("Layout")]
		public Color ShapeColor
		{
			get{return shapeColor;}
			set{shapeColor = value; SetBrush(); Invalidate();}
		}

		[Browsable(false)]
		public Point Location
		{
			get{return new Point(this.mRectangle.X,this.mRectangle.Y);}
			set{
				//we use the move method but it requires the delta value, not an absolute position!
				Point p = new Point(value.X-mRectangle.X,value.Y-mRectangle.Y);
				//if you'd use this it would indeed move the bundle but not the connector s of the bundle
				//this.mRectangle.X = value.X; this.mRectangle.Y = value.Y; Invalidate();
				this.Move(p);
			}
		}

		public override Rectangle Rectangle
		{
			get{return mRectangle;}/*
			set{mRectangle = value;

            this.Invalidate();              }*/
		}

		#endregion

		#region Constructor

		
		public ShapeBase(IModel model) : base(model)
		{
            mRectangle = new Rectangle(0, 0, 100, 70);

            connectors = new CollectionBase<IConnector>();
            shapeColor = ArtPallet.RandomLowSaturationColor;
            SetBrush();
		}

        public ShapeBase()
            : base()
        {
            mRectangle = new Rectangle(0, 0, 100, 70);

            connectors = new CollectionBase<IConnector>();
            shapeColor = ArtPallet.RandomLowSaturationColor;
            SetBrush();
        }

		#endregion

		#region Methods
        public override  MenuItem[] ShapeMenu()
        {
            return null;
        }
		public override void Init()
		{
            base.Init();
            //shapeColor = ArtPallet.RandomLowSaturationColor;
            //SetBrush();
		}


		public IConnector HitConnector(Point p)
		{
			for(int k=0;k<connectors.Count;k++)
			{
				if(connectors[k].Hit(p))
				{
					connectors[k].Hovered=true;
					connectors[k].Invalidate();
					return connectors[k];
				}
				else
				{
					connectors[k].Hovered=false;
					connectors[k].Invalidate();
				
				}

				
			}
			return null;

		}

		private void SetBrush()
		{
			shapeBrush = new SolidBrush(shapeColor);
			
		}

		public override void Paint(System.Drawing.Graphics g)
		{
			return;
		}

		public override bool Hit(System.Drawing.Point p)
		{
			return false;
		}

		public override void Invalidate()
		{
			Rectangle r = Rectangle;
			r.Offset(-10,-10);
			r.Inflate(40,40);
            if(Model!=null)
                Model.RaiseOnInvalidateRectangle(r);
		}



		public override void Move(Point p)
		{
            Rectangle recBefore = mRectangle;
            recBefore.Inflate(20, 20);

			this.mRectangle.X += p.X;
			this.mRectangle.Y += p.Y;
		

			for(int k=0;k<this.connectors.Count;k++)
			{
				connectors[k].Move(p);
			}
            //refresh things
            this.Invalidate(recBefore);//position before the move
			this.Invalidate();//current position

		}

        
        public  void Scale(Point origin, double scaleX, double scaleY)
        {
            #region Variables
            //temporary variables to assign the new location of the connectors            
            double a, b;
            //the new location of the connector
            Point p;
            //calculated/scaled/biased corners of the new rectangle
            double ltx = 0, lty = 0, rbx = 0, rby = 0;
            
            Rectangle currentRectangle = Rectangle;
            //we only need to transform the LT and RB corners since the rest of the rectangle can be deduced from that
            /*
            PointF[] corners = new PointF[]{new PointF(currentRectangle.X, currentRectangle.Y),                                                            
                                                            new PointF(currentRectangle.Right, currentRectangle.Bottom),                                                            
            
             };
             */
            Rectangle newRectangle;            
            #endregion

            #region Transformation matrix

            ltx = Math.Round((currentRectangle.X - origin.X) * scaleX,1) +  origin.X;
            lty=  Math.Round((currentRectangle.Y - origin.Y) * scaleY,1) +  origin.Y;

            rbx =  Math.Round(( currentRectangle.Right -  origin.X) *  scaleX,1) +  origin.X;
            rby = Math.Round((currentRectangle.Bottom - origin.Y) * scaleY,1) + origin.Y;

            //corners[0] = new PointF
            //Matrix m = new Matrix();
            // m.Translate(-origin.X, -origin.Y,MatrixOrder.Append);
            // m.Scale(scaleX, scaleY, MatrixOrder.Append);
            // m.Translate(origin.X, origin.Y, MatrixOrder.Append);
            #endregion
            
            //transfor the LTRB points of the current rectangle
            //m.TransformPoints(corners);

            #region Bias
            /*
            if(currentRectangle.Y <= origin.Y + ViewBase.TrackerOffset && origin.Y - ViewBase.TrackerOffset <= currentRectangle.Y)
            {
                //do not scale in the Y-direction
                lty = currentRectangle.Y;
            }
            
            if(currentRectangle.X <= origin.X+ ViewBase.TrackerOffset && origin.X - ViewBase.TrackerOffset <= currentRectangle.X)
            {
                //do not scale in the X-direction
                ltx = currentRectangle.X;
            }
            
            if(currentRectangle.Right <= origin.X + ViewBase.TrackerOffset && origin.X - ViewBase.TrackerOffset <= currentRectangle.Right)
            {
                //do not scale in the X-direction
                rbx = currentRectangle.Right;
            }
            
            if(currentRectangle.Bottom <= origin.Y + ViewBase.TrackerOffset && origin.Y - ViewBase.TrackerOffset <= currentRectangle.Bottom)
            {
                //do not scale in the Y-direction            
                rby = currentRectangle.Bottom;
            } 
             */
            #endregion
            /*
            ltx = Math.Round(ltx);
            lty = Math.Round(lty);
            rbx = Math.Round(rbx);
            rby = Math.Round(rby);
             * */
            //now we can re-create the rectangle of this shape            
            //newRectangle = RectangleF.FromLTRB(ltx, lty, rbx, rby);
            newRectangle = Rectangle.FromLTRB(Convert.ToInt32(ltx), Convert.ToInt32(lty), Convert.ToInt32(rbx), Convert.ToInt32(rby));
            //if ((newRectangle.Width <= 50 && scaleX < 1) || (newRectangle.Height <= 50 && scaleY < 1))
            //    return;
            #region Scaling of the connectors
            //Note that this mechanism is way easier than the calculations in the old Netron library
            //and it also allows dynamic connectors.
            foreach (IConnector cn in this.connectors)            
             {
                 //De profundis: ge wilt het gewoon nie weten hoeveel bloed, zweet en tranen ik in de onderstaande berekeningen heb gestoken...
                 //met al de afrondingen en meetkundinge schaalafwijkingen..tis een wonder dat ik eruit ben geraakt.
                 
                 //Scaling preserves proportions, so we calculate the proportions before the rectangle was resized and
                 //re-assign the same proportion after the rectangle is resized.
                 //I have tried many, many different possibilities but the accumulation of double-to-int conversions is a real pain.
                 //The only working solution I found was to cut things off after the first decimal.
                 a = Math.Round(((double) cn.Point.X - (double) mRectangle.X) / (double) mRectangle.Width, 1) * newRectangle.Width + ltx;
                 b = Math.Round(((double) cn.Point.Y - (double) mRectangle.Y) / (double) mRectangle.Height, 1) * newRectangle.Height + lty;                 
                 p = new Point(Convert.ToInt32(a), Convert.ToInt32(b));
                 cn.Point = p;
             }
            #endregion
             //assign the new calculated rectangle to this shape
             this.mRectangle = newRectangle;
            //invalidate the space before the resize; very important if the scaling is a contraction!
             this.Invalidate(currentRectangle);
            //invalidate the current situation
             this.Invalidate();
        }



        public virtual void Transform(int x, int y, int width, int height)
        {
            double a, b;
            Point p;
            foreach(IConnector cn in this.connectors)
            {
                a = Math.Round(((double) cn.Point.X - (double) mRectangle.X) / (double) mRectangle.Width, 1) * width + x - cn.Point.X;
                b = Math.Round(((double) cn.Point.Y - (double) mRectangle.Y) / (double) mRectangle.Height, 1) * height + y - cn.Point.Y;
                p = new Point(Convert.ToInt32(a), Convert.ToInt32(b));
                cn.Move(p);    
            }
            mRectangle = new Rectangle(x,y,width,height);
           

        }


		#endregion

   
	}
}
