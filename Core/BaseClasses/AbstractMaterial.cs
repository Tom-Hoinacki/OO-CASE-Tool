using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    public abstract class AbstractMaterial : IShapeMaterial
    {
        #region Properties


        private bool mGliding = true;
        public bool Gliding
        {
            get { return mGliding; }
            set { mGliding = value; }
        }


        private bool mResizable;
        public bool Resizable
        {
            get { return mResizable; }
            set { mResizable = value; }
        }
        private Rectangle mRectangle;
        public Rectangle Rectangle
        {
            get { return mRectangle; }
          
        }


        private IShape mShape;
        public IShape Shape
        {
            get { return mShape; }
            set { mShape = value; }
        }


        private IController mController;


        private bool mVisible = true;
        public bool Visible
        {
            get { return mVisible; }
            set { mVisible = value; }
        }


        #endregion


        #region Constructor
        protected AbstractMaterial()
        {
        }
        #endregion
  

        #region Methods
        public abstract void Paint(System.Drawing.Graphics g);


        public virtual object GetService(Type serviceType)
        {
            return null;
        }

        #endregion



        public void Transform(Rectangle rectangle)
        {
            this.mRectangle = rectangle;
        }
    }
}
