using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Netron.NetronLight
{

    public enum TextPosition { From, To, Mid }
    public class ConnectionText : DDTObject1
    {
        #region Field
        //string fromText;
        //string toText;
        //string midText;
        DDTConnection conn;
        TextPosition pos;
        #endregion

        #region Properties
        public override string EntityName
        {
            get { return "ConnectionText"; }
        }
        #endregion

        #region Constructor
        //using!!!
        public ConnectionText(DDTConnection conn, TextPosition pos)
            : base("ConnectionText", false)
        {
            this.conn = conn;
            this.pos = pos;
        }

        public ConnectionText(IModel s)
            : base(s)
        {
            //Init();
        }

        public ConnectionText()
            : base("ConnectionText", false)
        {
            //Init(); 
        }


        public DDTConnection Connection
        {
            get { return conn; }
            set { this.conn = value; }
        }


        public override void Init()
        {
            base.Init();
            this.Height = 40;
            this.Width = 50;

        }
        #endregion

        #region Methods
        public override bool Hit(System.Drawing.Point p)
        {
            Rectangle r = new Rectangle(p, new Size(5, 5));
            return Rectangle.Contains(r);
        }

        public override void Paint(System.Drawing.Graphics g)
        {

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            //Brush ADTShapeBrush = new LinearGradientBrush(new Point(((int)(Rectangle.X)), ((int)(Rectangle.Y))), new Point(((int)(Rectangle.X + Rectangle.Width)), ((int)(Rectangle.Y))), Color.LightGoldenrodYellow, Color.WhiteSmoke);

            //g.FillRectangle(ADTShapeBrush, Rectangle);

            //the edge of the bundle
            String text = "";
            Rectangle rec=new Rectangle();
            rec.Width = 50;
            rec.Height = 40;
            switch (pos)
            {
                case TextPosition.From:
                    rec.Location = getFromLocation();
                   
                    text = conn.Tfrom;
                    break;

                case TextPosition.To:
                    rec.Location = getToLocation();
                    text = conn.Tto;
                    break;

                case TextPosition.Mid:
                    rec.Location = getMidLocation();
                    text = conn.Tmid;
                    break;
                default: break;
            }



            Pen TextPen = new Pen(Color.Transparent, 1.5F);
            TextPen.DashStyle = DashStyle.Dot;

            if (Hovered || IsSelected)
            {
                TextPen.Color = selectedColor;
                TextPen.Width = selectedWidth;
                g.DrawRectangle(TextPen, rec);

            }
            else
            {
                g.DrawRectangle(TextPen, rec);
            }
            /*
            //the connectors
			for(int k=0;k<Connectors.Count;k++)
			{
				Connectors[k].Paint(g);
			}           
            */
            //here we keep it really simple:
            if (!text.Equals("") && text != null)
            {
                g.DrawString(text, DDTTextFont, DDTTextBrush, rec, DDTTextFormat);
            }

        }

        private Point getFromLocation()
        {
            Point point = new Point();
            if (conn.From.Point.X < conn.To.Point.X)
            {
                point = new Point(conn.From.Point.X + 5, conn.From.Point.Y - 40);

            }
            else
            {
                point = new Point(conn.From.Point.X - 50, conn.From.Point.Y - 40);

            }
            return point;
        }

        private Point getToLocation()
        {
            Point point = new Point();
            if (conn.From.Point.X < conn.To.Point.X)
            {
                point = new Point(conn.To.Point.X - 50, conn.To.Point.Y - 40);

            }
            else
            {
                point = new Point(conn.To.Point.X + 5, conn.To.Point.Y - 40);

            }
            return point;
        }

        private Point getMidLocation()
        {
            Point point = new Point(conn.From.Point.X + (conn.To.Point.X - conn.From.Point.X) / 2 - 25, conn.From.Point.Y + (conn.To.Point.Y - conn.From.Point.Y) / 2 - 40);

            return point;
        }
        #endregion
    }

}

