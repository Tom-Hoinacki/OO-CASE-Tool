using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    public interface ITracker : IPaintable
    {

       
        Point Hit(Point p);

        void Transform(Rectangle rectangle);

        bool ShowHandles { get; set;}
    }
}
