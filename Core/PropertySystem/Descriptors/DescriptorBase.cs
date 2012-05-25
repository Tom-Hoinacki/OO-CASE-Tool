using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Netron.NetronLight
{
    abstract class DescriptorBase : CustomTypeDescriptor
    {
        #region Fields
        //the provider to which this descriptor is attached
        private TypeDescriptionProvider provider;
        private Type type;
        private PropertyDescriptorCollection mProperties;
        #endregion

        #region Properties
        protected PropertyDescriptorCollection Properties
        {
            get { return mProperties; }
        }
        #endregion

        #region Constructors

        public DescriptorBase(ShapeProvider provider, ICustomTypeDescriptor parentdescriptor, Type objectType)
            : base(parentdescriptor)
        {
            this.provider = provider;
            this.type = objectType;
            mProperties = new PropertyDescriptorCollection(null);
        }

        public DescriptorBase(TypeDescriptionProvider provider, Type objectType)
            : base()
        {
            this.provider = provider;
            this.type = objectType;
            mProperties = new PropertyDescriptorCollection(null);            
        }
        #endregion

        #region Methods

        #region AddProperty overloads
        public void AddProperty(string name, Type type)
        {
            PropertySpec widthSpec = new PropertySpec(name, type);
            PropertySpecDescriptor pd = widthSpec.ToPropertyDescriptor();
            pd.OnGetValue += new EventHandler<PropertyEventArgs>(GetValue);
            pd.OnSetValue += new EventHandler<PropertyEventArgs>(SetValue);
            mProperties.Add(pd);
        }
        public void AddProperty(string name, Type type, string category)
        {
            PropertySpec widthSpec = new PropertySpec(name, type, category);
            PropertySpecDescriptor pd = widthSpec.ToPropertyDescriptor();
            pd.OnGetValue += new EventHandler<PropertyEventArgs>(GetValue);
            pd.OnSetValue += new EventHandler<PropertyEventArgs>(SetValue);
            mProperties.Add(pd);
        }
        public void AddProperty(string name, Type type, string category, string description)
        {
            PropertySpec widthSpec = new PropertySpec(name, type, category, description);
            PropertySpecDescriptor pd = widthSpec.ToPropertyDescriptor();
            pd.OnGetValue += new EventHandler<PropertyEventArgs>(GetValue);
            pd.OnSetValue += new EventHandler<PropertyEventArgs>(SetValue);
            mProperties.Add(pd);
        }

        public void AddProperty(string name, Type type, string category, string description, object defaultValue)
        {
            PropertySpec widthSpec = new PropertySpec(name, type, category, description, defaultValue);
            PropertySpecDescriptor pd = widthSpec.ToPropertyDescriptor();
            pd.OnGetValue += new EventHandler<PropertyEventArgs>(GetValue);
            pd.OnSetValue += new EventHandler<PropertyEventArgs>(SetValue);
            mProperties.Add(pd);
        }

        public void AddProperty(string name, Type type, string category, string description, object defaultValue, Type editor, Type typeConverter)
        {
            PropertySpec widthSpec = new PropertySpec(name, type, category, description, defaultValue, editor, typeConverter);
            PropertySpecDescriptor pd = widthSpec.ToPropertyDescriptor();
            pd.OnGetValue += new EventHandler<PropertyEventArgs>(GetValue);
            pd.OnSetValue += new EventHandler<PropertyEventArgs>(SetValue);
            mProperties.Add(pd);
        }
        #endregion


        

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return mProperties;
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            return GetProperties(null);
        }
        protected virtual void GetValue(object sender, PropertyEventArgs e)
        {

        }

        protected virtual void SetValue(object sender, PropertyEventArgs e)
        {
        } 
        #endregion
    }
}
