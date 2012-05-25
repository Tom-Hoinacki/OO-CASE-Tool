using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Netron.NetronLight
{
	public abstract class LayoutBase : ILayout
    {
        #region Fields
        private IModel mModel;
        #endregion

        #region Properties
        public IModel Model
        {
            get { return mModel; }
            set { mModel = value; }
        }
        #endregion

		#region Constructor
        protected LayoutBase(IModel model) 
		{
			mModel = model;
		}

		#endregion

        #region Methods
        public virtual void Layout()
        {

        }
        #endregion
		
	}

}
