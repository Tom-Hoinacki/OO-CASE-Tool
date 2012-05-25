using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Netron.NetronLight
{
	public class ImageShape : SimpleShapeBase, ISerializable
	{
		#region Fields

		#region the connectors
        private Connector cBottom, cLeft, cRight, cTop;	
		private string mImagePath;
		private Image mImage;
		#endregion
		#endregion
		
		#region Properties
        public override string EntityName
        {
            get
            {
                return "Image shape";
            }
        }
		public string ImagePath
		{
			get{return mImagePath;}
			set{
				if(value==string.Empty) return;
				if(File.Exists(value))
				{
					try
					{
						mImage = Image.FromFile(value);
						Transform(Rectangle.X, Rectangle.Y, mImage.Width, mImage.Height);
					}
					catch(Exception exc)
					{
						
					}
					mImagePath = value;
				}
				else
					MessageBox.Show("The specified file does not exist.","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public Image Image
		{
			get{return mImage;}
			set{
				if(value==null) return;
				mImage = value;
				mImagePath = string.Empty;
				Transform(Rectangle.X, Rectangle.Y, mImage.Width, mImage.Height);			
			}
		}
		#endregion

		#region Constructor

		public ImageShape() : base()
		{
            Init();
		}
		public ImageShape(IModel site) : base(site)
		{
            Init();
		}
        public override void Init()
        {
            base.Init();
            //the initial size
            Transform(0, 0, 200, 50);
            #region Connectors
            cTop = new Connector(new Point((int) (Rectangle.Left + Rectangle.Width / 2), Rectangle.Top), Model);
            cTop.Name = "Top connector";
            cTop.Parent = this;
            Connectors.Add(cTop);

            cRight = new Connector(new Point(Rectangle.Right, (int) (Rectangle.Top + Rectangle.Height / 2)), Model);
            cRight.Name = "Right connector";
            cRight.Parent = this;
            Connectors.Add(cRight);

            cBottom = new Connector(new Point((int) (Rectangle.Left + Rectangle.Width / 2), Rectangle.Bottom), Model);
            cBottom.Name = "Bottom connector";
            cBottom.Parent = this;
            Connectors.Add(cBottom);

            cLeft = new Connector(new Point(Rectangle.Left, (int) (Rectangle.Top + Rectangle.Height / 2)), Model);
            cLeft.Name = "Left connector";
            cLeft.Parent = this;
            Connectors.Add(cLeft);
            #endregion
        }
		protected ImageShape(SerializationInfo info, StreamingContext context) 
		{
            /*
			TopNode = (Connector) info.GetValue("TopNode", typeof(Connector));
			TopNode.BelongsTo = this;
			Connectors.Add(TopNode);			

			BottomNode = (Connector) info.GetValue("BottomNode", typeof(Connector));
			BottomNode.BelongsTo = this;
			Connectors.Add(BottomNode);			

			LeftNode = (Connector) info.GetValue("LeftNode", typeof(Connector));
			LeftNode.BelongsTo = this;
			Connectors.Add(LeftNode);			

			RightNode = (Connector) info.GetValue("RightNode", typeof(Connector));
			RightNode.BelongsTo = this;
			Connectors.Add(RightNode);			
            
			IsResizable = true;
            */
			try
			{
				mImage = info.GetValue("mImage", typeof(Image)) as Image;
				if(mImage !=null) 
				{
					//the following line will reset the original image size, but I guess it's safer to keep the serialized size;
					//Rectangle = new RectangleF(Rectangle.X, Rectangle.Y, mImage.Width, mImage.Height);
					mImagePath = info.GetString("mImagePath");
				}
				
			}
			catch
			{
				
			}
			
		}
		#endregion	

		#region Properties
		
	
		#endregion

		#region Methods
		public override MenuItem[] ShapeMenu()
		{
	
			MenuItem item= new MenuItem("Reset image size",new EventHandler(OnResetImageSize));
			MenuItem[] items = new MenuItem[]{item};

			return items;
		}
		private void OnResetImageSize(object sender, EventArgs e)
		{
			Transform(Rectangle.X, Rectangle.Y, mImage.Width, mImage.Height);
			this.Invalidate();
		}

		public  Bitmap GetThumbnail()
		{
			Bitmap bmp=null;
			try
			{
				Stream stream=Assembly.GetExecutingAssembly().GetManifestResourceStream("Netron.GraphLib.BasicShapes.Resources.ImageShape.gif");
					
				bmp= Bitmap.FromStream(stream) as Bitmap;
				stream.Close();
				stream=null;
			}
			catch(Exception exc)
			{
				Trace.WriteLine(exc.Message,"ImageShape.GetThumbnail");
			}
			return bmp;
		}
		
		public override void Paint(Graphics g)
		{
			base.Paint(g);
            //if(RecalculateSize)
            //{
            //    Rectangle = new RectangleF(new PointF(Rectangle.X,Rectangle.Y),
            //        g.MeasureString(this.Text,Font));	
            //    Rectangle = System.Drawing.RectangleF.Inflate(Rectangle,10,10);
            //    RecalculateSize = false; //very important!
            //}
			if(mImage==null)
			{
				g.FillRectangle(ShapeBrush, Rectangle);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				g.DrawString("Image shape", ArtPallet.DefaultFont, Brushes.Black, Rectangle.X + (Rectangle.Width / 2), Rectangle.Y + 3, sf);
			}
			else
				g.DrawImage(mImage, Rectangle);			

			
				
					
			
		}

	


		public  void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            /*
			base.GetObjectData (info, context);

			info.AddValue("TopNode", TopNode, typeof(Connector));

			info.AddValue("BottomNode", BottomNode, typeof(Connector));

			info.AddValue("LeftNode", LeftNode, typeof(Connector));

			info.AddValue("RightNode", RightNode, typeof(Connector));

			info.AddValue("mImage", mImage, typeof(Image));

			info.AddValue("mImagePath", this.mImagePath);
             * */
		}

		


	


		


		
		#endregion
	}

}







		
