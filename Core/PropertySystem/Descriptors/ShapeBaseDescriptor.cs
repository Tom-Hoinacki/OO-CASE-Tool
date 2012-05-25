using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
namespace Netron.NetronLight
{
    class ShapeBaseDescriptor : DescriptorBase
    {

        #region Constants
        private const string constLayout = "Layout";
        #endregion

        #region Fields
        
        #endregion

        #region Properties
        
        #endregion

        #region Constructor       
        public ShapeBaseDescriptor(ShapeProvider provider, Type objectType)
            : base(provider, objectType)
        {            
            AddBaseProperties();
        }
        #endregion

        #region Methods
        private void AddBaseProperties()
        {
            this.AddProperty("Width", typeof(int), constLayout, "The width of the shape.");
            this.AddProperty("Height", typeof(int), constLayout, "The height of the shape.");            
            this.AddProperty("Location", typeof(Point), constLayout, "The location of the shape.", Point.Empty, typeof(UITypeEditor), typeof(Netron.NetronLight.PointConverter));
        }
    

        protected override void GetValue(object sender, PropertyEventArgs e)
        {
            switch(e.Name.ToLower())
            {
                case "width":
                    e.Value = (e.Component as ShapeBase).Width;
                    break;
                case "height":
                    e.Value = (e.Component as ShapeBase).Height;
                    break;                
                case "location":
                    e.Value = (e.Component as ShapeBase).Location;
                    break;
                
                    
            }
            
                
        }

        

        protected override void SetValue(object sender, PropertyEventArgs e)
        {
            switch(e.Name.ToLower())
            {
                case "width":
                    (e.Component as ShapeBase).Width = (int) e.Value;
                    break;
                case "height":
                    (e.Component as ShapeBase).Height = (int) e.Value;
                    break;                
                case "location":
                    Point p = (Point) e.Value;
                    (e.Component as ShapeBase).Location = new Point(p.X, p.Y);
                    break;
        }
        }

       
        #endregion
    }
}
