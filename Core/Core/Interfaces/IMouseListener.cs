using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    public interface IMouseListener : IInteraction
    {
        void MouseDown(MouseEventArgs e);
        void MouseMove(MouseEventArgs e);
        void MouseUp(MouseEventArgs e);
    }
}
