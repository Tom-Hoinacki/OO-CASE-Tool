using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    interface IKeyboardListener : IInteraction
    {

        void KeyDown(KeyEventArgs e);

        void KeyUp(KeyEventArgs e);

        void KeyPress(KeyPressEventArgs e);

    }
}
