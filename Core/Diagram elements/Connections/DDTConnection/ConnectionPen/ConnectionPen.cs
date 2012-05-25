using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Netron.NetronLight
{
    public static class ConnectionPen 
    {
        
        #region Fields
         

        private static Pen normalConnection =new Pen(Color.Black, 1.5F);

        private static Pen singleArrowConnection = new Pen(Color.Black, 1.5F);

        private static Pen doubleArrowConnection = new Pen(Color.Black, 1.5F);

        private static Pen oneToOneConnection = new Pen(Color.Black, 1.5F);

        private static Pen oneToManyConnection = new Pen(Color.Black, 1.5F);

        private static Pen manyToManyConnection = new Pen(Color.Black, 1.5F);

        private static Pen inheritConnection = new Pen(Color.Black, 1.5F);

        private static Pen compositionConnection = new Pen(Color.Black, 1.5F);

        private static Pen dashedArrowConnection = new Pen(Color.Black, 1.5F); 


        #endregion

        #region Properties
        public static Pen normal
        {
            get
            {
                return normalConnection;
            }
            set
            {
                normalConnection = value;
            }
        }


        public static Pen singleArrow
        {
            get
            {
                return singleArrowConnection;
            }
            set
            {
                singleArrowConnection = value;
            }
        }


        public static Pen doubleArrow 
        {
            get
            {
                return doubleArrowConnection;
            }
            set
            {
                doubleArrowConnection = value;
            }
        }


        public static Pen oneToOne 
        {
            get
            {
                return oneToOneConnection;
            }
            set
            {
                oneToOneConnection = value;
            }
        }


        public static Pen oneToMany 
        {
            get
            {
                return oneToManyConnection;
            }
            set
            {
                oneToManyConnection = value;
            }
        }



        public static Pen manyToMany 
        {
            get
            {
                return manyToManyConnection;
            }
            set
            {
                manyToManyConnection = value;
            }
        }

        public static Pen inherit
        {
            get
            {
                return inheritConnection;
            }
            set
            {
                inheritConnection = value;
            }
        }

        public static Pen composition
        {
            get
            {
                return compositionConnection;
            }
            set
            {
                compositionConnection = value;
            }
        }

        public static Pen dashedArrow
        {
            get
            {
                return dashedArrowConnection;
            }
            set
            {
                dashedArrowConnection = value;
            }
        }
        
        
        #endregion

        #region Constructor

        public static CustomLineCap drawTriangleCap()
        {
            GraphicsPath hPath = new GraphicsPath();

            hPath.AddLine(new Point(-5, -5), new Point(5, -5));
            hPath.AddLine(new Point(5, -5), new Point(0, 0));
            hPath.AddLine(new Point(0, 0), new Point(-5, -5));
            hPath.CloseFigure();

            CustomLineCap cap = new CustomLineCap(null, hPath);

            //g.FillRegion(Brushes.White, new Region(hPath));  
            return cap;
        }

        public static CustomLineCap drawDiamondCap()
        {
            GraphicsPath hPath = new GraphicsPath();

            hPath.AddLine(new Point(0, 0), new Point(-5, -7));
            hPath.AddLine(new Point(-5, -7), new Point(0, -14));
            hPath.AddLine(new Point(0, -14), new Point(5, -7));
            hPath.AddLine(new Point(5, -7), new Point(0, 0));
            hPath.CloseFigure();

            
            CustomLineCap cap = new CustomLineCap(null, hPath);

            //g.FillPath(Brushes.Black, hPath);  
            return cap;
        }

        //one to Many cap, the "One" side arrow
        public static CustomLineCap drawArrow()
        {
            GraphicsPath hPath = new GraphicsPath();

            //hPath.AddLine(new Point(-5, -5), new Point(5, -5));
            hPath.AddLine(new Point(5, -5), new Point(0, 0));
            hPath.AddLine(new Point(0, 0), new Point(-5, -5));

            CustomLineCap cap = new CustomLineCap(null, hPath);
            //cap.SetStrokeCaps(LineCap.Round, LineCap.Round);
            return cap;
        }
        //one to Many cap, the "Many" side arrow
        public static CustomLineCap drawDoubleArrow()
        {
            GraphicsPath hPath = new GraphicsPath();

            //hPath.AddLine(new Point(-5, -5), new Point(5, -5));
            hPath.AddLine(new Point(5, -5), new Point(0, 0));
            hPath.AddLine(new Point(-5, -5), new Point(0,0));
            hPath.AddLine(new Point(0, 0), new Point(0, -5));
            hPath.AddLine(new Point(-5, -10), new Point(0, -5));
            hPath.AddLine(new Point(5, -10), new Point(0,-5));

            CustomLineCap cap = new CustomLineCap(null, hPath);
            //cap.SetStrokeCaps(LineCap.Round, LineCap.Round);
            return cap;
        }

        

        public static void Init()
        {

             
         
            AdjustableArrowCap  cap = new AdjustableArrowCap(5, 7, true);
            AdjustableArrowCap capUnfilled = new AdjustableArrowCap(8, 7, false);
            AdjustableArrowCap wideCap = new AdjustableArrowCap(15, 7, true);

            singleArrow.EndCap = LineCap.Custom;
            

            doubleArrow.CustomStartCap = cap;
            doubleArrow.CustomEndCap = cap;

            dashedArrow.CustomEndCap = cap;
       
        }
 
        #endregion

        public static Pen getConnection(ConnectionType type, Graphics g) 
        
        {
            

            switch (type) 
            {
                case ConnectionType.NORMAL:
                    return normalConnection;
                case ConnectionType.SINGLEARROW:
                    singleArrow.CustomEndCap = new AdjustableArrowCap(5, 7, true);
                    return singleArrowConnection;
                case ConnectionType.DOUBLEARROW:
                    doubleArrow.CustomStartCap =new AdjustableArrowCap(5, 7, true);
                    doubleArrow.CustomEndCap =new AdjustableArrowCap(5, 7, true);
                    return doubleArrowConnection;
                case ConnectionType.ONETOONE:
                    oneToOne.CustomStartCap = drawArrow();
                    oneToOne.CustomEndCap = drawArrow();
                    return oneToOneConnection;
                case ConnectionType.ONETOMANY:
                    oneToMany.CustomStartCap = drawArrow();
                    oneToMany.CustomEndCap = drawDoubleArrow();
                    return oneToManyConnection;
                case ConnectionType.MANYTOMANY:
                    manyToMany.CustomStartCap = drawDoubleArrow();
                    manyToMany.CustomEndCap = drawDoubleArrow();
                    return manyToManyConnection;
                case ConnectionType.WIDEARROW:
                    //inherit.CustomEndCap = drawTriangleCap();
                    inheritConnection.CustomEndCap = new AdjustableArrowCap(15, 7, true);
                    return inheritConnection;
                case ConnectionType.DIAMONDARROW:
                    composition.CustomEndCap = drawDiamondCap();
                    return compositionConnection;
                case ConnectionType.DASHEDARROW: 
                    dashedArrow.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    dashedArrow.CustomEndCap = drawArrow();
                    return dashedArrowConnection;
                default:
                    return normalConnection;
            
            }
        
        }

        public static void setPen(Color color, float width)
        {
            normal.Color = color;
            singleArrow.Color=color;
            doubleArrow.Color=color;
            oneToOne.Color=color;
            oneToMany.Color=color; 
            manyToMany.Color=color;
            inherit.Color = color;
            composition.Color = color;
            dashedArrow.Color = color;


            normal.Width = width;
            singleArrow.Width = width;
            doubleArrow.Width = width;
            oneToOne.Width = width;
            oneToMany.Width = width;
            manyToMany.Width = width;
            inherit.Width = width;
            composition.Width = width;
            dashedArrow.Width = width;
        }
        

    }
}
 