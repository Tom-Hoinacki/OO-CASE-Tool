using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
namespace Netron.NetronLight
{
    public abstract class SimpleShapeBase : ShapeBase, ISimpleShape
    {
        #region Fields
        private string text = string.Empty;
        private Rectangle mTextRectangle;
        #endregion

        #region Properties
        [Browsable(true), Description("The text shown on the shape"), Category("Layout")]
        public virtual string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }
        public Rectangle TextRectangle
        {
            get
            {
                return mTextRectangle;
            }
            set
            {
                mTextRectangle = value;
            }
        }
        #endregion

        #region Constructor
        public SimpleShapeBase() : base()
        {
            mTextRectangle = Rectangle;
        }
        public SimpleShapeBase(IModel model)
            : base(model)
        {
            mTextRectangle = Rectangle;
        }
        
        #endregion

        #region Methods

        public override void Move(Point p)
        {
            base.Move(p);
            this.mTextRectangle.X += p.X;
            this.mTextRectangle.Y += p.Y;
        }
      
        #endregion
    }
}
