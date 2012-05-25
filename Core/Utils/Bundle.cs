using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
namespace Netron.NetronLight
{

    [Serializable()]
    public class Bundle : DiagramEntityBase, IBundle, ISerializable
    {

        #region Fields
        private CollectionBase<IDiagramEntity> mEntities;
        #endregion

        #region Properties
        public CollectionBase<IDiagramEntity> Entities
        {
            get
            {
                return mEntities;
            }
        }
        public override string EntityName
        {
            get { return "bundle"; }
        }

        public override Rectangle Rectangle
        {
            get {
                System.Drawing.Rectangle union = System.Drawing.Rectangle.Empty;
                foreach (IDiagramEntity entity in mEntities)
                {
                    union = System.Drawing.Rectangle.Union(union,entity.Rectangle);
                }
                //maybe this should be inflated a little here?
                return union;
            }
             //set { throw new InconsistencyException("The rectangle of a bundle is the union of its constituents and cannot be set."); }
        }

        #endregion

        #region Constructor

        public Bundle(IModel model) : base(model)
        {
            mEntities = new CollectionBase<IDiagramEntity>();
        }

        protected Bundle(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        public Bundle() {
            mEntities = new CollectionBase<IDiagramEntity>();
        }

        public Bundle(CollectionBase<IDiagramEntity> collection)
        {
            
            mEntities = new CollectionBase<IDiagramEntity>();
            //we could assign it directly but let's make sure the collection does not
            //contain unwanted elements
            foreach (IDiagramEntity entity in collection)
            {
                if ((entity is IShape) || (entity is IConnection) || (entity is IGroup))
                    mEntities.Add(entity);
            }
             
            //the following line would give problem. The event handler attached to the Selection would be triggered when
            //the mEntities collection is changed!
            //mEntities = collection;

        }

        #endregion

        #region Methods
        public override  MenuItem[] ShapeMenu()
        {
            return null;
        }

      

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            foreach (IDiagramEntity entity in mEntities)
            {
                entity.Paint(g);
            }
        }

        public override bool Hit(System.Drawing.Point p)
        {
            foreach (IDiagramEntity entity in mEntities)
            {
                if (entity.Hit(p)) return true;
            }
            return false;
        }

        public override void Invalidate()
        {
            foreach (IDiagramEntity entity in mEntities)
            {
                entity.Invalidate();
            }
        }

        public override void Move(System.Drawing.Point p)
        {
            foreach (IDiagramEntity entity in mEntities)
            {
                entity.Move(p);
            }
        }
      
       
        #endregion
    }
}
