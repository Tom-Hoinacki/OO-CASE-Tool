using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    interface IDragDropListener : IInteraction
    {

        void OnDragDrop(DragEventArgs e);

        void OnDragEnter(DragEventArgs e);
        void OnDragLeave(EventArgs e);

        void OnDragOver(DragEventArgs e);

        void GiveFeedback(GiveFeedbackEventArgs e);

    }
}
