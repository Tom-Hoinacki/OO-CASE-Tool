using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
namespace Netron.NetronLight
{
    public class PointConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type t)
        {
            if(t == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, t);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(value is Point)
            {
                Point point = (Point) value;
                return "(" + point.X + "," + point.Y + ")";
            }
            return base.ConvertTo(context, culture, value, destinationType);
            
            
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string) 
             {

                try
                {
                    string thething = (string) value;
                    //remove brackets if any
                    thething = thething.Replace("(", "").Replace(")", "");
                    //now we should have only a comma
                    string[] parts = thething.Split(new char[] { ',' });
                    return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
                }
                catch(Exception)
                {

                    return Point.Empty;
                }
            }
            return base.ConvertFrom(context, culture, value);
            
            
            
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value, attributes);
        }
    }
}
