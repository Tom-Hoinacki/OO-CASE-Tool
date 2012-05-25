using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    abstract class TrackerBase : ITracker
    {
        #region Fields
        private Rectangle mRectangle;
        #endregion

        #region Properties
        public Rectangle Rectangle
        {
            get
            {
                return mRectangle;
            }
            set
            {
                mRectangle = value;
            }
        }
        private bool mShowHandles;
        public bool ShowHandles
        {
            get { return mShowHandles; }
            set { mShowHandles = value; }
        }
        #endregion

        #region Constructors

        public TrackerBase()
        {
        }
        public TrackerBase(Rectangle rectangle)
        {
            mRectangle = rectangle;
        }
        #endregion
    
        #region Methods
        public abstract void Paint(Graphics g);
        //{
        //    g.DrawRectangle(ArtPallet.HighlightPen, mRectangle);
        //}
        public abstract Point Hit(Point p);
        public abstract void Transform(Rectangle rectangle);
        #endregion

    }
}
