using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public interface IGroup : IDiagramEntity
    {
        CollectionBase<IDiagramEntity> Entities { get; set;}

        void CalculateRectangle();
    }
}
