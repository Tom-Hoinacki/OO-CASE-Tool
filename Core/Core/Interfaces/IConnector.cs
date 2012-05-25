using System;
using System.Drawing;
namespace Netron.NetronLight
{
	public interface IConnector : IDiagramEntity
	{
		#region Properties
		Point Point {get; set;}
		IConnector AttachedTo {get; set;}
		CollectionBase<IConnector> AttachedConnectors {get;}
		#endregion

		#region Methods
		void AttachConnector(IConnector child);

        void DetachConnector(IConnector child);

        void DetachFromParent();

        void AttachTo(IConnector parent);
		#endregion
	}
}
