
namespace Netron.NetronLight {
	public interface IConnection : IDiagramEntity {

		IConnector From{
			get;
			set;
		}

		IConnector To{
			get;
			set;
		}
	} 

}