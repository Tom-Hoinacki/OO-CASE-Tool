using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;
namespace Netron.NetronLight
{  
    public class IconMaterial : AbstractMaterial
    {
        #region Fields
        private Bitmap mIcon;
        #endregion

        #region Properties
        public Bitmap Icon
        {
            get
            {
                return mIcon;
            }
            set
            {
                mIcon = value;
            }
        }
        #endregion

        #region Constructor
        public IconMaterial( string resourceLocation)    :base()
        {

            mIcon = GetBitmap(resourceLocation);
        }

        protected Bitmap GetBitmap(string resourceLocation)
        {
            if(resourceLocation.Length == 0)
                throw new InconsistencyException("Invalid icon specification.");
            try
            {
                return  new Bitmap(this.GetType(), resourceLocation);
            }
            catch
            {

                throw;
            }
        }
        public IconMaterial()
            : base()
        {
        }

        #endregion

        #region Methods
        public override void Paint(Graphics g)
        {
            if (!Visible) return;            
            if(mIcon != null)
                g.DrawImage(mIcon, Rectangle);
        }
        #endregion
        
    }
}
