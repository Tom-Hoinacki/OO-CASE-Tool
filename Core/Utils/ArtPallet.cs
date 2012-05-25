using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight
{
    public static class ArtPallet
    {

        #region Fields
        private static Pen mTrackerPen = new Pen(Color.DimGray, 1.5F);
        private static Brush mGripBrush = Brushes.WhiteSmoke;
        private static Font mDefaultFont = new Font("Arial", 8.5F, FontStyle.Bold);
        private static Random rnd = new Random();
        private static Pen mBlackPen = new Pen(Brushes.Black, 1F);

        private static Brush mShadowBrush = new SolidBrush(Color.FromArgb(30, Color.Black));
        private static Pen mHighlightPen = new Pen(Brushes.OrangeRed, 1.7F);
        private static Pen mShadowPen = new Pen(Color.FromArgb(30, Color.Black), 1F);

        private static Pen mConnectionPen = new Pen(Color.Black,1F);

        private static Pen mConnectionHighlightPen = new Pen(Color.OrangeRed, 1F);
        #endregion

        #region Properties
        public static Pen ConnectionPen
        {
            get
            {
                return mConnectionPen;
            }
            set
            {
                mConnectionPen = value;
            }
        }
        public static Pen ConnectionHighlightPen
        {
            get
            {
                return mConnectionHighlightPen;
            }
            set
            {
                mConnectionHighlightPen = value;
            }
        }

        public static Brush GripBrush
        {
            get { return mGripBrush; }
            set { mGripBrush = value; }
        }
        #endregion

        #region Constructor
        public static void Init()
        {
            mTrackerPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            AdjustableArrowCap ccap = new AdjustableArrowCap(5, 7, true);            

            mConnectionPen.EndCap = LineCap.Custom;
            mConnectionPen.CustomEndCap = ccap;

            mConnectionHighlightPen.EndCap = LineCap.Custom; 
            mConnectionHighlightPen.CustomEndCap = ccap;



        }
        public static Font DefaultFont
        {
            get
            {
                return ArtPallet.mDefaultFont;
            }
            set
            {
                ArtPallet.mDefaultFont = value;
            }
        }
        public static Pen BlackPen
        {
            get
            {
                return ArtPallet.mBlackPen;
            }
            set
            {
                ArtPallet.mBlackPen = value;
            }
        }
        public static Pen TrackerPen
        {
            get { 
                return ArtPallet.mTrackerPen; }
            set { ArtPallet.mTrackerPen = value; }
        }
        public static Pen HighlightPen
        {
            get
            {
                return ArtPallet.mHighlightPen;
            }
            set
            {
                ArtPallet.mHighlightPen = value;
            }
        }

        public static Brush ShadowBrush
        {
            get
            {
                return ArtPallet.mShadowBrush;
            }
            set
            {
                ArtPallet.mShadowBrush = value;
            }
        }
        public static Pen ConnectionShadow
        {
            get
            {
                return ArtPallet.mShadowPen;
            }
            set
            {
                ArtPallet.mShadowPen = value;
            }
        }

        public static Color RandomColor
        {
            get
            {
                return Color.FromArgb(rnd.Next(10, 250), rnd.Next(10, 250), rnd.Next(10, 250));
            }
        }

        public static Color RandomBlues
        {
            get
            {
                return (Color) Utils.HSL2RGB((rnd.NextDouble() * 20D + 150D) / 255D, (rnd.NextDouble() * 150D + 100D) / 255D, (rnd.NextDouble() * 50D + 150D) / 255D);
            }
        }

        public static Color RandomLowSaturationColor
        {
            get
            {
                return (Color) Utils.HSL2RGB((rnd.NextDouble() * 255D) / 255D, (rnd.NextDouble() * 20D + 30D) / 255D, (rnd.NextDouble() * 20D + 130D) / 255D);
            }
        }
        #endregion
        
    }
}
