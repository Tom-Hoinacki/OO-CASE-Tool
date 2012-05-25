using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    public interface IPaintable
    {
        Rectangle Rectangle
        {
            get;           
        }
        void Paint(Graphics g);
    }
}
