using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Netron.NetronLight
{
    public abstract class SmallObject : IDDTObject
    {
        #region Fields

        protected Font DDTTextFont;
        protected StringFormat DDTTextFormat;
        protected string objName;
        protected Brush DDTTextBrush = Brushes.DarkBlue;

        //the color and width of the pen to draw a selected shape.
        protected Color selectedColor = Color.DodgerBlue;
        protected float selectedWidth = 3F;

        //whether to shrink the shape;
        protected bool Shrink = false;

        #endregion

        #region Constructor

        public SmallObject()
            : base()
        { 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }
        public SmallObject(IModel model)
            : base(model)
        { 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }

        public SmallObject(string text, bool shrink)
            : base()
        {
            this.objName = text;
            Text = objName;
            this.Shrink = shrink; 
            setTextFormat();
            setTextFont();
            setRectangleSize(); 
        }

        public SmallObject(string text)
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
            if (Shrink)
            {
                DDTTextFont = new Font("Arial", 4F, FontStyle.Regular);
            }
            else
            {
                DDTTextFont = new Font("Arial", 7F, FontStyle.Bold);
            }
        }

        protected override void setRectangleSize()
        {
            if (Shrink)
            {
                Height = 50;
                Width = 50;
                //resest the text rectangle size
                //TextRectangle = Rectangle;
            }
            else
            {
                Height = 70;
                Width = 70;
                //resest the text rectangle size
                //TextRectangle = Rectangle;
            }
        }

        public override string EntityName
        {
            get { return "SmallObject"; }
        }

        public void enlarge()
        {
            Height = Height + 20;
            Width = Width + 20;
        }
        public void shrink()
        {
            Height = Height-20;
            Width = Width-20;
        }
        public void rename(string text)
        {
            Text = text;
        }

        #endregion
    }
}
