using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    class Page : IPage
    {

        #region Events
        public event EventHandler<EntityEventArgs> OnEntityAdded;
        public event EventHandler<EntityEventArgs> OnEntityRemoved;
        public event EventHandler OnClear;
        public event EventHandler<CancelableEntityEventArgs> OnBeforeResize;
        #endregion

        #region Fields
        private string mName;
        private Layer mDefaultLayer;
        private CollectionBase<ILayer> mLayers;
        public CollectionBase<ILayer> Layers
        {
            get { return mLayers; }
            set { mLayers = value; }
        }

        public ILayer DefaultLayer
        {
            get { return mDefaultLayer; }
        }

        private Ambience mAmbience;
        public Ambience Ambience
        {
            get { return mAmbience; }
            set { mAmbience = value; }
        }

        #endregion

        #region Properties
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        #endregion

        #region Constructor
        public Page(string name)
        {
            mLayers = new CollectionBase<ILayer>();
            

            //the one and only and indestructible layer
            mDefaultLayer = new Layer("Default Layer");
            mDefaultLayer.OnEntityAdded += new EventHandler<EntityEventArgs>(defaultLayer_OnEntityAdded);
            mDefaultLayer.OnEntityRemoved += new EventHandler<EntityEventArgs>(mDefaultLayer_OnEntityRemoved);
            mDefaultLayer.OnClear += new EventHandler(mDefaultLayer_OnClear);
            mLayers.Add(mDefaultLayer);

            mName = name;
        }

        void mDefaultLayer_OnClear(object sender, EventArgs e)
        {
            EventHandler handler = OnClear;
            if (handler != null)
                handler(sender, e);
        }

        void mDefaultLayer_OnEntityRemoved(object sender, EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityRemoved;
            if (handler != null)
                handler(sender, e);
        }

        void defaultLayer_OnEntityAdded(object sender, EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityAdded;
            if (handler != null)
                handler(sender, e);
        }
        #endregion
  
    }
}
