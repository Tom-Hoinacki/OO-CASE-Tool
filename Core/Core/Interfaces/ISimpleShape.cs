using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public interface ISimpleShape : IShape
    {
        string Text
        {
            get;
            set;
        }
    }
}
