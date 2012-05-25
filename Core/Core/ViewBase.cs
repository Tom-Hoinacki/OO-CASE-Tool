using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Diagnostics;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    //http://st-www.cs.uiuc.edu/users/smarch/st-docs/mvc.html

    public abstract class ViewBase : IDisposable, IView
    {

        #region Events
        public event EventHandler<CursorEventArgs> OnCursorChange;
        #endregion

        #region Fields
        private ITracker mTracker;
        private IAnts mAnts;
        private IGhost mGhost;
        private IModel mModel;
        private Brush mBackgroundBrush;
        private IDiagramControl parentControl;
        private RectangleF clientRectangle;
        private Cursor mCurrentCursor = Cursors.Default;
        #endregion

        #region Properties
        internal readonly static int TrackerOffset = 5;
        public Cursor CurrentCursor
        {
            get { return mCurrentCursor; }
            set
            {
                mCurrentCursor = value;
                RaiseOnCursorChange(value);
            }
        }
        internal Brush BackgroundBrush
        {
            get
            {
                return mBackgroundBrush;
            }
        }
        public IModel Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }
        public  IGhost Ghost
        {
            get { return mGhost; }
            protected set { mGhost = value;}
        }
        public IAnts Ants
        {
            get { return mAnts; }
            protected set { mAnts = value; }
        }

        public ITracker Tracker
        {
            get { return mTracker; }
            set { mTracker = value; }
        }

        #endregion

        #region Constructor
        protected ViewBase(IDiagramControl surface)
        {
            if (surface == null)
                throw new NullReferenceException();
            this.parentControl = surface;
            this.parentControl.SizeChanged += new EventHandler(parentControl_SizeChanged);
        }

        protected ViewBase()
        { }
        
        #endregion

        #region Methods
        void parentControl_SizeChanged(object sender, EventArgs e)
        {
            clientRectangle = parentControl.ClientRectangle;
            //redefine the brush in function of the chosen background type
            SetBackgroundType(Model.Ambience.BackgroundType);
            Invalidate();
        }
        public virtual void Paint(Graphics g)
        {
            //paint the scene graph
            foreach (IDiagramEntity entity in mModel.Paintables)
            {
                entity.Paint(g);                
            }
        }

        
        public void PaintBackground(Graphics g)
        {
            if (g == null) return;
            if (mModel.Ambience.BackgroundType == CanvasBackgroundTypes.Gradient)
                g.FillRectangle(mBackgroundBrush, clientRectangle);
        }

        public void AttachToModel(IModel model)
        {
            if (model == null)
                throw new ArgumentNullException("The model assigned to the view cannot be 'null'");
            mModel = model;
            mModel.OnAmbienceChanged += new EventHandler<AmbienceEventArgs>(mModel_OnAmbienceChanged);
            mModel.OnInvalidate += new EventHandler(mModel_OnInvalidate);
            mModel.OnInvalidateRectangle += new EventHandler<RectangleEventArgs>(mModel_OnInvalidateRectangle);
            mModel.OnCursorChange += new EventHandler<CursorEventArgs>(mModel_OnCursorChange);
        }

        void mModel_OnCursorChange(object sender, CursorEventArgs e)
        {
            this.RaiseOnCursorChange(e.Cursor);
        }

        void mModel_OnInvalidateRectangle(object sender, RectangleEventArgs e)
        {

            try
            {
                parentControl.Invalidate(Rectangle.Round(e.Rectangle));
            }
            catch(StackOverflowException)
            {
                //TODO: automatic exception report here?

                throw;
            }
        }

        void mModel_OnInvalidate(object sender, EventArgs e)
        {
            parentControl.Invalidate();
        }


        public void SetBackgroundType(CanvasBackgroundTypes value)
        {

            if (value == CanvasBackgroundTypes.Gradient)
                BuildGradientBrush();

        }
        void mModel_OnAmbienceChanged(object sender, AmbienceEventArgs e)
        {
            //redefine the brush in function of the chosen background type
            SetBackgroundType(mModel.Ambience.BackgroundType);
            //refresh everything
            Invalidate();
        }

        public void DetachFromModel(Model model)
        {
            throw new System.NotImplementedException();
        }
        #region Invalidate overloads
        public void Invalidate()
        {
            parentControl.Invalidate();
        }

        public void Invalidate(Rectangle rectangle)
        {
            this.parentControl.Invalidate(rectangle);
        }
        #endregion

        private void BuildGradientBrush()
        {
            if (mModel == null || clientRectangle == RectangleF.Empty) return;
            mBackgroundBrush = new LinearGradientBrush(clientRectangle, mModel.Ambience.GradientColor1, mModel.Ambience.GradientColor2, LinearGradientMode.Vertical);
        }

        private void RaiseOnCursorChange(Cursor cursor)
        {
            EventHandler<CursorEventArgs> handler = OnCursorChange;
            if (handler != null)
                handler(this, new CursorEventArgs(cursor));
        }

        public virtual  void PaintAntsRectangle(Point ltPoint, Point rbPoint)
        {
        }
        public virtual void PaintGhostRectangle(Point ltPoint, Point rbPoint)
        {
        }
        public virtual void PaintGhostLine(Point ltPoint, Point rbPoint)
        {
        }
        public virtual void PaintGhostEllipse(Point ltPoint, Point rbPoint)
        {
        }
        public virtual void PaintTracker(Rectangle rectangle, bool showHandles)
        { }
        public void ResetGhost()
        {
            if (mGhost == null) return;
            Rectangle rec = mGhost.Rectangle;
            rec.Inflate(10, 10);
            this.Invalidate(rec);            
            mGhost = null;
        }
        internal void ResetAnts()
        {
            mAnts = null;
        }
        public void ResetTracker()
        {
            if (mTracker == null) return;
            Rectangle rec = mTracker.Rectangle;
            rec.Inflate(20, 20);
            mTracker = null;
            Invalidate(rec);
        }
       
        public void ShowTracker()
        {
            if(Selection.SelectedItems != null && Selection.SelectedItems.Count > 0)
            {
                CollectionBase<IDiagramEntity> ents = Selection.SelectedItems;
                bool showHandles = false;

                Rectangle rec = ents[0].Rectangle;
                foreach (IDiagramEntity entity in ents)
                {
                    rec = Rectangle.Union(rec, entity.Rectangle);
                    showHandles |= entity.Resizable;
                }
                //make the tracker slightly bigger than the actual bounding rectangle
                rec.Inflate(TrackerOffset, TrackerOffset);

                this.PaintTracker(rec,showHandles);

            }
            else //if the selection is 'null' or empty we annihilate the current tracker
                ResetTracker();
        }
        #endregion

     

        #region Standard IDispose implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            
        }        
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                #region free managed resources
                if(mBackgroundBrush != null)
                {
                    mBackgroundBrush.Dispose();
                    mBackgroundBrush = null;
                }
                #endregion
            }
           
        }

        #endregion
    }
}
