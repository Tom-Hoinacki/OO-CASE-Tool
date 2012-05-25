using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
namespace Netron.NetronLight
{
	public class PropertyEventArgs : EventArgs
	{
		#region Fields
        private object mComponent;
		private object mValue;
        private string mName;                
		#endregion

		#region Properties
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }
		public object Value
		{
			get { return mValue; }
			set { mValue = value; }
		}
		public object Component
		{
			get
			{ 
				return mComponent;
			}
		}
		#endregion

		#region Constructors
		public PropertyEventArgs(object mComponent, string mName, object mValue)
		{
            this.mComponent = mComponent;
			this.mValue = mValue;
            this.mName = mName;
		}
		
		
		#endregion
	}

}
