using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

using System.Diagnostics;
using System.Windows.Forms;
namespace Netron.NetronLight.Win
{
    class View : ViewBase
    {
        #region Fields

        #endregion

        #region Constructor

        public View(IDiagramControl control)
            : base(control)
        {
            
            Selection.OnNewSelection += new EventHandler(Selection_OnNewSelection);
           // this.Model.OnEntityAdded += new EventHandler<EntityEventArgs>(Model_OnEntityAdded);
        }

        void Model_OnEntityAdded(object sender, EntityEventArgs e)
        {
            
        }

        void Selection_OnNewSelection(object sender, EventArgs e)
        {
            ShowTracker();
        }

        
        #endregion

        #region Methods
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            //draw the ghost and ants on top of the diagram
            if(Ants != null)
                Ants.Paint(g);
            if(Ghost != null)
                Ghost.Paint(g);
            if(Tracker != null)
                Tracker.Paint(g);
        }
        public override void PaintGhostEllipse(Point ltPoint, Point rbPoint)
        {
            Ghost = GhostsFactory.GetGhost(new Point[] { ltPoint, rbPoint }, GhostTypes.Ellipse);
        }
        public override void PaintGhostRectangle(Point ltPoint, Point rbPoint)
        {
            Ghost = GhostsFactory.GetGhost(new Point[] { ltPoint, rbPoint }, GhostTypes.Rectangle);
        }
        public override void PaintAntsRectangle(Point ltPoint, Point rbPoint)
        {
            Ants = AntsFactory.GetAnts(new Point[] { ltPoint, rbPoint }, AntTypes.Rectangle);
        }
        public override void PaintGhostLine(Point ltPoint, Point rbPoint)
        {
            Ghost = GhostsFactory.GetGhost(new Point[] { ltPoint, rbPoint }, GhostTypes.Line);
        }

        public override void PaintTracker(Rectangle rectangle, bool showHandles)
        {
            Tracker = TrackerFactory.GetTracker(rectangle, TrackerTypes.Default, showHandles);
            rectangle.Inflate(20, 20);
            this.Invalidate(rectangle);
        }

        #endregion

        #region Tracker

        private enum TrackerTypes
        {
            Default
        }

        private class TrackerFactory
        {

            private static ITracker defTracker;

            public static ITracker GetTracker(Rectangle rectangle, TrackerTypes type, bool showHandles)
            {
                switch(type)
                {
                    case TrackerTypes.Default:
                        if(defTracker == null) defTracker = new DefaultTracker();
                        defTracker.Transform(rectangle);
                        defTracker.ShowHandles = showHandles;
                        return defTracker;
                    default:
                        return null;
                }

            }
        }

        private class DefaultTracker  : TrackerBase
        {

            private const int gripSize = 4;
            private const int hitSize = 6;
            float mx, my, sx, sy;
          

            #region Constructor
            public DefaultTracker(Rectangle rectangle) : base(rectangle)
            {
                
            }
            public DefaultTracker()
                : base()
            { }
            #endregion


            public override void Transform(Rectangle rectangle)
            {
                this.Rectangle = rectangle;
            }


            public override  void Paint(Graphics g)
            {
                //the main rectangle
                g.DrawRectangle(ArtPallet.TrackerPen, Rectangle);
                #region Recalculate the size and location of the grips
                mx = Rectangle.X + Rectangle.Width / 2;
                my = Rectangle.Y + Rectangle.Height / 2;
                sx = Rectangle.Width /2;
                sy = Rectangle.Height /2;
                #endregion
                #region draw the grips
                if (!ShowHandles) return;
                
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1 ; y++)
                    {
                        if (x != 0 || y != 0) //not the middle one
                        {
                            g.FillRectangle(ArtPallet.GripBrush, mx + x * sx - gripSize / 2, my + y * sy - gripSize / 2, gripSize, gripSize);
                            g.DrawRectangle(ArtPallet.BlackPen, mx + x * sx - gripSize / 2, my + y * sy - gripSize / 2, gripSize, gripSize);
                        }
                    }
                }
                #endregion
            }

            public override Point Hit(Point p)
            {
                //no need to test if the handles are not shown
                if (!ShowHandles) return Point.Empty;

                for (int x = -1; x <= +1; x++)
                    for (int y = -1; y <= +1; y++)
                        if ((x != 0) || (y != 0))
                        {
                            if(new RectangleF(mx + x * sx - hitSize/2, my + y * sy - hitSize/2, hitSize, hitSize).Contains(p))
                                return new Point(x, y);
                        }
                return Point.Empty;
            }

        }

        #endregion

        #region Factories of visual effects

        private static class AntsFactory
        {
            #region Static fields
            private static RectAnts mRectangular;
            public readonly static Pen Pen = new Pen(Color.Black, 1f);
            #endregion

            #region Constructor
            static AntsFactory()
            {
                Pen.DashStyle = DashStyle.Dash;
            }
            #endregion

            #region Methods

            public static IAnts GetAnts(object pars, AntTypes type)
            {
                switch(type)
                {
                    case AntTypes.Rectangle:
                        if(mRectangular == null)
                            mRectangular = new RectAnts();
                        Point[] points = (Point[]) pars;
                        mRectangular.Start = points[0];
                        mRectangular.End = points[1];
                        return mRectangular;
                    default:
                        return null;
                }
            }
            #endregion

            #region Concretes
            private class RectAnts : AbstractAnt
            {

               

                #region Constructor
                public RectAnts(Point s, Point e)
                    : this()
                {
                    this.Start = s;
                    this.End = e;

                }
                public RectAnts() : base()
                {
                    Pen.DashStyle = DashStyle.Dash;
                }
                #endregion

                #region IPaintable Members

                public override void Paint(Graphics g)
                {
                    if(g == null)
                        return;
                    g.DrawRectangle(AntsFactory.Pen, Start.X, Start.Y, End.X - Start.X, End.Y - Start.Y);

                }

                #endregion
            }
            #endregion

            private abstract class AbstractAnt : IAnts
            {
                #region Fields
                private Point mStart;


                private Point mEnd;

                #endregion

                #region Properties

                public Point Start
                {
                    get
                    {
                        return mStart;
                    }
                    set
                    {
                        mStart = value;
                    }
                }
                public Point End
                {
                    get
                    {
                        return mEnd;
                    }
                    set
                    {
                        mEnd = value;
                    }
                }
               
                public Rectangle Rectangle
                {
                    get { return new Rectangle(mStart.X, mStart.Y, mEnd.X - mStart.X, mEnd.Y - mStart.Y); }
                    set {
                        mStart = new Point(value.X, value.Y);
                        mEnd = new Point(value.Right, value.Bottom);
                    }
                }
                #endregion

                #region Methods
                public abstract void Paint(Graphics g);
                #endregion

            }
        }

        private enum AntTypes
        {
            Rectangle
        }

        private static class GhostsFactory
        {
            #region Static fields
            public static readonly Brush Brush = new SolidBrush(Color.FromArgb(120, Color.LightYellow));
            private static RectGhost mRectangular;

            private static LineGhost mLine;

            private static EllipticGhost mEllipse;
            public readonly static Pen Pen = new Pen(Color.Green, 1f);
            #endregion

            #region Constructor

            #endregion

            #region Properties

            #endregion

            #region Methods (only static allowed in a static class)
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
            public static IGhost GetGhost(object pars, GhostTypes type)
            {
                Point[] points;
                switch(type)
                {
                    case GhostTypes.Rectangle:
                        if(mRectangular == null)
                            mRectangular = new RectGhost();
                        points = (Point[]) pars;
                        mRectangular.Start = points[0];
                        mRectangular.End = points[1];
                        return mRectangular;
                    case GhostTypes.Ellipse:
                        if(mEllipse == null)
                            mEllipse = new EllipticGhost();
                        points = (Point[]) pars;
                        mEllipse.Start = points[0];
                        mEllipse.End = points[1];
                        return mEllipse;
                    case GhostTypes.Line:
                        if(mLine == null)
                            mLine = new LineGhost();
                        points = (Point[]) pars;
                        mLine.Start = points[0];
                        mLine.End = points[1];
                        return mLine;
                    default:
                        return null;
                }
            }
            #endregion

            #region Concretes
            private class RectGhost : AbstractGhost
            {



                #region Constructor
                public RectGhost(Point s, Point e)
                    : base(s, e)
                {

                }
                public RectGhost()
                {
                }
                #endregion

                #region IPaintable Members
                public override void Paint(Graphics g)
                {
                    if(g == null)
                        return;
                    g.FillRectangle(GhostsFactory.Brush, Rectangle);
                    g.DrawRectangle(GhostsFactory.Pen, Rectangle);

                }

                #endregion
            }

            private class EllipticGhost : AbstractGhost
            {
                #region Constructor
                public EllipticGhost(Point s, Point e)
                    : base(s, e)
                {


                }
                public EllipticGhost()
                {
                }
                #endregion

                #region IPaintable Members
                public override void Paint(Graphics g)
                {
                    if(g == null)
                        return;
                    g.FillEllipse(GhostsFactory.Brush, Rectangle);
                    g.DrawEllipse(GhostsFactory.Pen, Rectangle);

                }

                #endregion
            }

            private class LineGhost : AbstractGhost
            {
                #region Constructor
                public LineGhost(Point s, Point e)
                    : base(s, e)
                {


                }
                public LineGhost()
                {
                }
                #endregion

                #region IPaintable Members
                public override void Paint(Graphics g)
                {
                    if(g == null)
                        return;
                    g.DrawLine(GhostsFactory.Pen, Start, End);
                }

                #endregion
            }

            private abstract class AbstractGhost : IGhost
            {
                #region Fields
                private Point mStart;


                private Point mEnd;

                #endregion

                #region Properties
                public Rectangle Rectangle
                {
                    get
                    {
                        return Rectangle.FromLTRB(Math.Min(mStart.X, mEnd.X), Math.Min(mStart.Y, mEnd.Y), Math.Max(mStart.X, mEnd.X), Math.Max(mStart.Y, mEnd.Y));
                    }
                    set { }
                }

                public Point Start
                {
                    get
                    {
                        return mStart;
                    }
                    set
                    {
                        mStart = value;
                    }
                }
                public Point End
                {
                    get
                    {
                        return mEnd;
                    }
                    set
                    {
                        mEnd = value;
                    }
                }
                #endregion

                #region Constructor
                protected AbstractGhost(Point s, Point e)
                {
                    this.mStart = s;
                    this.mEnd = e;
                }
                protected AbstractGhost()
                {
                }
                #endregion

                #region Methods

                public abstract void Paint(Graphics g);
                #endregion

            }
            #endregion
        }
        private enum GhostTypes
        {
            Rectangle,
            Ellipse,
            Line
        }
        #endregion
    }

}
