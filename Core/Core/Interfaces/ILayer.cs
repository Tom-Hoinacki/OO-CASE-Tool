using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public interface ILayer
    {
        CollectionBase<IDiagramEntity> Entities { get;}
    }
}
