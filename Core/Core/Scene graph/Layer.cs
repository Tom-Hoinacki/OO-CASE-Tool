using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    class Layer : ILayer
    {
        #region Events
        public event EventHandler<EntityEventArgs> OnEntityAdded;
        public event EventHandler<EntityEventArgs> OnEntityRemoved;
        public event EventHandler OnClear;
        #endregion

        #region Fields

        private CollectionBase<IDiagramEntity> mEntities;
        private string mName;
        
        #endregion

        #region Properties
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public CollectionBase<IDiagramEntity> Entities
        {
            get { return mEntities; }
            set { mEntities = value; }
        }

        
        #endregion
        
        #region Constructor

        public Layer(string name)
        {
            mName = name;
            mEntities = new CollectionBase<IDiagramEntity>();
            mEntities.OnItemAdded += new EventHandler<CollectionEventArgs<IDiagramEntity>>(mEntities_OnItemAdded);
            mEntities.OnItemRemoved += new EventHandler<CollectionEventArgs<IDiagramEntity>>(mEntities_OnItemRemoved);
            mEntities.OnClear += new EventHandler(mEntities_OnClear);
        }

        void mEntities_OnClear(object sender, EventArgs e)
        {
            EventHandler handler = OnClear;
            if (handler != null)
                handler(sender, e);
        }

        void mEntities_OnItemRemoved(object sender, CollectionEventArgs<IDiagramEntity> e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityRemoved;
            if (handler != null)
                handler(this, new EntityEventArgs(e.Item));
        }

        void mEntities_OnItemAdded(object sender, CollectionEventArgs<IDiagramEntity> e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityAdded;
            if (handler != null)
                handler(this, new EntityEventArgs(e.Item));
        }
        #endregion  
    }
}
