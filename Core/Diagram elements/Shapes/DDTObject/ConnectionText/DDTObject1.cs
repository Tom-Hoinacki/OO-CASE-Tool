using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Netron.NetronLight
{
    public abstract class DDTObject1 :  IDDTObject1
    {
        #region Fields
  
        protected Font DDTTextFont;
        protected StringFormat DDTTextFormat;
        protected string objName;
        protected Brush DDTTextBrush = Brushes.Black;

        //the color and width of the pen to draw a selected shape.
        protected Color selectedColor = Color.DodgerBlue;
        protected float selectedWidth = 4F;

        //whether to shrink the shape;
        protected bool shrink = false;

        #endregion

        #region Constructor




        public DDTObject1()
            : base()
        { 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }
        public DDTObject1(IModel model)
            : base(model)
        { 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }

        public DDTObject1(string text, bool shrink)
            : base()
        {
            this.objName = text;
            Text = objName;
            this.shrink = shrink; 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }

        public DDTObject1(string text)
            : base()
        {
            this.objName = text;
            Text = objName;
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }





        protected override void setTextFormat()
        {
            DDTTextFormat = new StringFormat();
            DDTTextFormat.Alignment = StringAlignment.Center;
            DDTTextFormat.LineAlignment = StringAlignment.Center;
        }

        protected override void setTextFont()
        {
            if (shrink)
            {
                DDTTextFont = new Font("Arial", 6F, FontStyle.Regular);
            }
            else
            {
                DDTTextFont = new Font("Arial", 8.5F, FontStyle.Bold);
            }
        }

        protected override void setRectangleSize()
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




    }
}
