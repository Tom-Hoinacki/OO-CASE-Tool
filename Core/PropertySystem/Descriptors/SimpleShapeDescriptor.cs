using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    class SimpleShapeDescriptor : ShapeBaseDescriptor
    {

        protected override void GetValue(object sender, PropertyEventArgs e)
        {
            switch (e.Name)
            {
                case "Demo":
                    e.Value = 123456;
                    break;
                default:
                    base.GetValue(sender, e);
                    break;
            }
        }

        protected override void SetValue(object sender, PropertyEventArgs e)
        {
            switch (e.Name)
            {                
                default:
                    base.SetValue(sender, e);
                    break;
            }
        }

        public SimpleShapeDescriptor(ShapeProvider provider, Type type)
            : base(provider, type)
        {
            this.AddProperty("Demo", typeof(int));            
        }


    }
}
