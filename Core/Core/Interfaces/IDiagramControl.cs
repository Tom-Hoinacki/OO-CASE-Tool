using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    public interface IDiagramControl
    {
        #region Events
        event DragEventHandler DragDrop;
        event DragEventHandler DragEnter;
        event EventHandler DragLeave;
        event DragEventHandler DragOver;

        event GiveFeedbackEventHandler GiveFeedback;
        event EventHandler SizeChanged;
        event MouseEventHandler MouseDown;
        event MouseEventHandler MouseUp;
        event MouseEventHandler MouseMove;
        event EventHandler MouseHover;
        event KeyEventHandler KeyDown;
        event KeyEventHandler KeyUp;
        event KeyPressEventHandler KeyPress;
        #endregion

        #region Properties
        Rectangle ClientRectangle { get; }
        #endregion

        #region Methods
        void Invalidate(Rectangle rc);
        void Invalidate();
        bool Focus();
        #endregion
        
    }
}
