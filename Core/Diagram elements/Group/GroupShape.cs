using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    class GroupShape : DiagramEntityBase, IGroup
    {
        #region Fields
        private CollectionBase<IDiagramEntity> mEntities;
        private Rectangle mRectangle;
        #endregion

        #region Properties
        public override string EntityName
        {
            get
            {
                return "Group shape";
            }
        }

        public override Rectangle Rectangle
        {
            get
            {

                return (Rectangle) mRectangle;
            }
        }
        public CollectionBase<IDiagramEntity> Entities
        {
            get { return mEntities; }
            set {
                
                    throw new InconsistencyException("You cannot set the entities, use the already instantiated collection to add or remove items.");

                
            }
        }
        public CollectionBase<IDiagramEntity> Leafs
        {
            get
            {
                CollectionBase<IDiagramEntity> flatList = new CollectionBase<IDiagramEntity>();
                foreach (IDiagramEntity entity in mEntities)
                {
                    if (entity is IGroup)
                        Utils.TraverseCollect(entity as IGroup, ref flatList);
                    else
                        flatList.Add(entity);
                }
                return flatList;
            }
        }
        #endregion

        #region Constructor
        public GroupShape(IModel model) : base(model)
        {
            this.mEntities = new CollectionBase<IDiagramEntity>();
            this.mEntities.OnItemAdded += new EventHandler<CollectionEventArgs<IDiagramEntity>>(mEntities_OnItemAdded);
            this.mEntities.OnClear += new EventHandler(mEntities_OnClear);
            this.mEntities.OnItemRemoved += new EventHandler<CollectionEventArgs<IDiagramEntity>>(mEntities_OnItemRemoved);
        }
        #endregion

        #region Methods
        public override MenuItem[] ShapeMenu()
        {
            return null;
        }
        void mEntities_OnItemRemoved(object sender, CollectionEventArgs<IDiagramEntity> e)
        {
            CalculateRectangle();
        }

        void mEntities_OnClear(object sender, EventArgs e)
        {
            mRectangle = Rectangle.Empty;
        }

        void mEntities_OnItemAdded(object sender, CollectionEventArgs<IDiagramEntity> e)
        {
            if(mEntities.Count == 1)
                mRectangle = e.Item.Rectangle;
            else
            {
                mRectangle = Rectangle.Union((Rectangle) mRectangle, e.Item.Rectangle);
            }
        }

        public  void CalculateRectangle()
        {
            if (mEntities == null || mEntities.Count == 0)
                return;
            Rectangle rec = mEntities[0].Rectangle;                        
            foreach (IDiagramEntity entity in Entities)
            {
                //cascade the calculation if necessary
                if (entity is IGroup) (entity as IGroup).CalculateRectangle();

                rec = Rectangle.Union(rec, entity.Rectangle);
            }
            this.mRectangle = rec;
        }


        public override void Paint(System.Drawing.Graphics g)
        {
            foreach(IDiagramEntity entity in mEntities)
            {
                entity.Paint(g);
            }
        }

        public override bool Hit(System.Drawing.Point p)
        {
            foreach(IDiagramEntity entity in mEntities)
            {
                if(entity.Hit(p))
                    return true;
            }
            return false;
        }

        public override void Invalidate()
        {
            if(mRectangle == null)
                return;
            Rectangle rec = mRectangle;
            rec.Inflate(20, 20);
            Model.RaiseOnInvalidateRectangle(rec);
        }

        public override void Move(System.Drawing.Point p)
        {
            //no need to invalidate since it'll be done by the individual move actions
            foreach(IDiagramEntity entity in mEntities)
            {
                entity.Move(p);
            }
            mRectangle.X += p.X;
            mRectangle.Y += p.Y;
        }
      

        #endregion
    }
}
