using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public interface IBundle : IDiagramEntity
    {
        CollectionBase<IDiagramEntity> Entities { get;}


      
    }
}
