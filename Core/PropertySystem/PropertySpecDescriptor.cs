using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Netron.NetronLight
{
    internal class PropertySpecDescriptor : PropertyDescriptor
    {
        #region events
        public event EventHandler<PropertyEventArgs> OnGetValue;
        public event EventHandler<PropertyEventArgs> OnSetValue;
		 
	    #endregion

        #region Fields
        private PropertySpec item;
        #endregion

        #region Constructor
        public PropertySpecDescriptor(PropertySpec item, Attribute[] attributes) : base(item.Name, attributes)
        {
            this.item = item;
        }
        #endregion

        #region Methods

        public override Type ComponentType
        {
            get
            {
                return item.GetType();
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return (Attributes.Matches(ReadOnlyAttribute.Yes));
            }
        }

        public override Type PropertyType
        {
            get
            {
                return Type.GetType(item.TypeName);
            }
        }

        public override bool CanResetValue(object component)
        {
            if(item.DefaultValue == null)
                return false;
            else
                return !this.GetValue(component).Equals(item.DefaultValue);
        }

        public override object GetValue(object component)
        {
            // Have the property bag raise an event to get the current value
            // of the property.

            PropertyEventArgs e = new PropertyEventArgs(component, base.Name, null);
            RaiseOnGetValue(e);
            return e.Value;
        }

        private void RaiseOnGetValue(PropertyEventArgs e)
        {
            EventHandler<PropertyEventArgs> handler = OnGetValue;
            if(handler != null)
                handler(this,e);
        }


        private void RaiseOnSetValue(PropertyEventArgs e)
        {
            EventHandler<PropertyEventArgs> handler = OnSetValue;
            if(handler != null)
                handler(this,e);
        }

        public override void ResetValue(object component)
        {
            SetValue(component, item.DefaultValue);
        }

        public override void SetValue(object component, object value)
        {
            // Have the property bag raise an event to set the current value
            // of the property.

            PropertyEventArgs e = new PropertyEventArgs(component, Name, value);
            RaiseOnSetValue(e);
        }

        public override bool ShouldSerializeValue(object component)
        {
            object val = this.GetValue(component);

            if(item.DefaultValue == null && val == null)
                return false;
            else
                return !val.Equals(item.DefaultValue);
        }

        #endregion
    }
}
