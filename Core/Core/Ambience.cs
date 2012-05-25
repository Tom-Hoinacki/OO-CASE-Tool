using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
namespace Netron.NetronLight
{
    public class Ambience :  IDisposable
    {
        #region Events
        public event EventHandler<AmbienceEventArgs> OnAmbienceChanged;
        #endregion

        #region Fields
        private Model mModel;
        private CanvasBackgroundTypes mBackgroundType;
        private Color mGradientColor1;
        private Color mGradientColor2;
        private Color mBackgroundColor;
        #endregion

        #region Properties


        public CanvasBackgroundTypes BackgroundType
        {
            get { return this.mBackgroundType; }
            set
            {
                this.mBackgroundType = value;
                RaiseOnAmbienceChanged();
            }
        }

        public Color GradientColor1
        {
            get { return mGradientColor1; }
            set
            {
                mGradientColor1 = value;
                RaiseOnAmbienceChanged();
            }
        }
        public Color GradientColor2
        {
            get { return mGradientColor2; }
            set
            {
                mGradientColor2 = value;
                RaiseOnAmbienceChanged();
            }
        }
        public Color BackgroundColor
        {
            get { return mBackgroundColor; }
            set
            {
                mBackgroundColor = value;
                //notify the world that things have changed
                RaiseOnAmbienceChanged();

            }
        }

        internal Model Model
        {
            get {
                return mModel;
            }
        }
        #endregion

        #region Constructor
        public Ambience(Model model)
        {
            if (model == null)
                throw new ArgumentNullException("The Model is 'null'");

            //set default ambience
            mBackgroundColor = Color.WhiteSmoke;        
            mBackgroundType = CanvasBackgroundTypes.FlatColor;
            mGradientColor1 = Color.WhiteSmoke;
            mGradientColor2 = Color.SteelBlue;
            mModel = model;
        }
        #endregion

        #region Methods
       
        protected virtual void RaiseOnAmbienceChanged()
        {
            EventHandler<AmbienceEventArgs> handler = OnAmbienceChanged;
            if (handler != null)
            {
                handler(this, new AmbienceEventArgs(this));
            }
        }

        #endregion

        #region Standard IDispose implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);


        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                #region free managed resources

                #endregion
            }

        }

        #endregion
    }
}
