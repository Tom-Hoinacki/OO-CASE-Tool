using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Netron.NetronLight
{
    class ShapeProvider : TypeDescriptionProvider
    {
        #region Fields
        private TypeDescriptionProvider baseProvider;
        private static SimpleShapeDescriptor simpleShapeDescriptor;

        
        #endregion

        #region Properties
        
        
        #endregion

        #region Constructor
        public ShapeProvider()
        {
            simpleShapeDescriptor = new SimpleShapeDescriptor(this, typeof(SimpleShapeBase));
        }
        #endregion

        #region Methods
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        { 
            if(typeof(SimpleShapeBase).IsInstanceOfType(instance))
            {                  
                return simpleShapeDescriptor;
            }            
            else //if nothing found use the base descriptor
               return base.GetTypeDescriptor(objectType, instance);

       }
        #endregion

   }
  
}
