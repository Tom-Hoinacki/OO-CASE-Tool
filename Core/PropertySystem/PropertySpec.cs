using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
namespace Netron.NetronLight
{
	[Serializable] public class PropertySpec
	{
		#region Fields
		private Attribute[] attributes;
		private string category;
		private object defaultValue;
		private string description;
		private string editor;
		private string name;
		private string type;
		private string typeConverter;

		#endregion

		#region Properties
		public Attribute[] Attributes
		{
			get { return attributes; }
			set { attributes = value; }
		}

		public string Category
		{
			get { return category; }
			set { category = value; }
		}

		public string ConverterTypeName
		{
			get { return typeConverter; }
			set { typeConverter = value; }
		}

		public object DefaultValue
		{
			get { return defaultValue; }
			set { defaultValue = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public string EditorTypeName
		{
			get { return editor; }
			set { editor = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string TypeName
		{
			get { return type; }
			set { type = value; }
		}
		#endregion

		#region Constructors
		public PropertySpec(string name, string type) : this(name, type, null, null, null) { }

		public PropertySpec(string name, Type type) :
			this(name, type.AssemblyQualifiedName, null, null, null) { }

		public PropertySpec(string name, string type, string category) : this(name, type, category, null, null) { }

		public PropertySpec(string name, Type type, string category) :
			this(name, type.AssemblyQualifiedName, category, null, null) { }

		public PropertySpec(string name, string type, string category, string description) :
			this(name, type, category, description, null) { }

		public PropertySpec(string name, Type type, string category, string description) :
			this(name, type.AssemblyQualifiedName, category, description, null) { }

		public PropertySpec(string name, string type, string category, string description, object defaultValue)
		{
			this.name = name;
			this.type = type;
			this.category = category;
			this.description = description;
			this.defaultValue = defaultValue;
			this.attributes = null;
		}

		public PropertySpec(string name, Type type, string category, string description, object defaultValue) :
			this(name, type.AssemblyQualifiedName, category, description, defaultValue) { }

		public PropertySpec(string name, string type, string category, string description, object defaultValue,
			string editor, string typeConverter) : this(name, type, category, description, defaultValue)
		{
			this.editor = editor;
			this.typeConverter = typeConverter;
		}

		public PropertySpec(string name, Type type, string category, string description, object defaultValue,
			string editor, string typeConverter) :
			this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor, typeConverter) { }

		public PropertySpec(string name, string type, string category, string description, object defaultValue,
			Type editor, string typeConverter) :
			this(name, type, category, description, defaultValue, editor.AssemblyQualifiedName,
			typeConverter) { }

		public PropertySpec(string name, Type type, string category, string description, object defaultValue,
			Type editor, string typeConverter) : 
			this(name, type.AssemblyQualifiedName, category, description, defaultValue,
			editor.AssemblyQualifiedName, typeConverter) { }

		public PropertySpec(string name, string type, string category, string description, object defaultValue,
			string editor, Type typeConverter) :
			this(name, type, category, description, defaultValue, editor, typeConverter.AssemblyQualifiedName) { }

		public PropertySpec(string name, Type type, string category, string description, object defaultValue,
			string editor, Type typeConverter) :
			this(name, type.AssemblyQualifiedName, category, description, defaultValue, editor,
			typeConverter.AssemblyQualifiedName) { }

		public PropertySpec(string name, string type, string category, string description, object defaultValue,
			Type editor, Type typeConverter) :
			this(name, type, category, description, defaultValue, editor.AssemblyQualifiedName,
			typeConverter.AssemblyQualifiedName) { }

		public PropertySpec(string name, Type type, string category, string description, object defaultValue,
			Type editor, Type typeConverter) :
			this(name, type.AssemblyQualifiedName, category, description, defaultValue,
			editor.AssemblyQualifiedName, typeConverter.AssemblyQualifiedName) { }


		#endregion

        #region Methods
        internal PropertySpecDescriptor ToPropertyDescriptor()
        {
            ArrayList attrs = new ArrayList();
            // If a category, description, editor, or type converter are specified
            // in the thisSpec, create attributes to define that relationship.
            if(this.Category != null)
                attrs.Add(new CategoryAttribute(this.Category));

            if(this.Description != null)
                attrs.Add(new DescriptionAttribute(this.Description));

            if(this.EditorTypeName != null)
                attrs.Add(new EditorAttribute(this.EditorTypeName, typeof(UITypeEditor)));

            if(this.ConverterTypeName != null)
                attrs.Add(new TypeConverterAttribute(this.ConverterTypeName));

            // Additionally, append the custom attributes associated with the
            // thisSpec, if any.
            if(this.Attributes != null)
                attrs.AddRange(this.Attributes);

            Attribute[] attrArray = (Attribute[]) attrs.ToArray(typeof(Attribute));

            // Create a new this descriptor for the this item, and add
            // it to the list.
            return new PropertySpecDescriptor(this, attrArray);
        }
            #endregion
    
        }

}
