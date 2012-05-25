using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    public interface IPage
    {
        #region Events
        event EventHandler<EntityEventArgs> OnEntityAdded;
        event EventHandler<EntityEventArgs> OnEntityRemoved;
        event EventHandler OnClear;
        #endregion

        #region Properties
        CollectionBase<ILayer> Layers { get;}
        ILayer DefaultLayer { get;}
        Ambience Ambience { get;}
        #endregion
        
    }
}
