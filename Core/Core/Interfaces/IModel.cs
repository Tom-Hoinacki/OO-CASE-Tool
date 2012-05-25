using System;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    public interface  IModel
    {

        #region Events
        event EventHandler<AmbienceEventArgs> OnAmbienceChanged;
        event EventHandler<ConnectionCollectionEventArgs> OnConnectionCollectionChanged;
        event EventHandler<DiagramInformationEventArgs> OnDiagramInformationChanged;
        event EventHandler OnInvalidate;
        event EventHandler<RectangleEventArgs> OnInvalidateRectangle;
        event EventHandler<EntityEventArgs> OnEntityAdded;
        event EventHandler<EntityEventArgs> OnEntityRemoved;
        event EventHandler<CursorEventArgs> OnCursorChange;
        #endregion

        #region Properties
        CollectionBase<IConnection> Connections { get; }
        ShapeCollection Shapes { get; }

        CollectionBase<IDiagramEntity> Paintables { get;}
        IPage CurrentPage { get;}
        Ambience Ambience { get;}
        CollectionBase<IPage> Pages { get;}
        #endregion

        #region Methods
        #region Diagram actions
        void AddConnection(IConnection connection);

        void AddShape(IShape shape);

        void AddShape(ShapeCollection shapeCollection);

        void Clear();

        void RemoveShape(IShape shape);

        void Remove(IDiagramEntity entity);
        #endregion

        void RaiseOnInvalidate();
        void RaiseOnInvalidateRectangle(RectangleF rectangle);
        void RaiseOnCursorChange(Cursor cursor);
        #endregion
    }
}
