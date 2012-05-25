using System;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
	public interface IShape : IDiagramEntity
	{
		#region Events
		
		#endregion

		#region Properties
        CollectionBase<IConnector> Connectors { get;}
		Point Location {get; set;}
		Color ShapeColor {get; set;}
		int Height {get; set;}
		int Width {get; set;}
		
	

        
		#endregion

		#region Methods
		IConnector HitConnector(Point p);

        void Transform(int x, int y, int width, int height);
		#endregion
	}
}