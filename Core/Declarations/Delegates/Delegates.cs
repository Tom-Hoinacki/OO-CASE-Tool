using System;
using System.Windows.Forms;

namespace Netron.NetronLight
{
	
    public delegate void CollectionAddInfo<T>(CollectionBase<T> collection, EntityEventArgs e);
    public delegate void CollectionRemoveInfo<T>(CollectionBase<T> collection, EntityEventArgs e);
    public delegate void CollectionClearInfo<T>(CollectionBase<T> collection, EventArgs e);	
	public delegate void PropertiesInfo(object ent);	
	
}
