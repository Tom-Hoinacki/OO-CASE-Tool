using System;
using System.Drawing;
namespace Netron.NetronLight
{
    public interface IView
    {
        #region Events
        event EventHandler<CursorEventArgs> OnCursorChange;
        #endregion

        #region Properties
        System.Windows.Forms.Cursor CurrentCursor { get; set;}

        IGhost Ghost { get;}

        IModel Model { get; set; }

        ITracker Tracker { get; set;}
        #endregion

        #region Methods

        void Invalidate();
        void Invalidate(System.Drawing.Rectangle rectangle);
        void Paint(System.Drawing.Graphics g);
        void PaintBackground(System.Drawing.Graphics g);
        void SetBackgroundType(CanvasBackgroundTypes type);
        void ResetGhost();
        void ResetTracker();
        void PaintGhostRectangle(Point start, Point end);
        void PaintGhostLine(Point start, Point end);
        void PaintGhostEllipse(Point start, Point end);
        void PaintAntsRectangle(Point ltPoint, Point rbPoint);
        void PaintTracker(Rectangle rectangle, bool showHandles);
        void AttachToModel(IModel model);
        void ShowTracker();
        #endregion
    }
}
