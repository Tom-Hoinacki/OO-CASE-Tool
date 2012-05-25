using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
namespace Netron.NetronLight
{  
    public class ClickableIconMaterial : IconMaterial, IMouseListener, IHoverListener
    {

        #region Constructor
        public ClickableIconMaterial( string resourceLocation)   : base( resourceLocation)
        {
            Resizable = false;
        }
        public ClickableIconMaterial()
            : base()
        {
            Resizable = false;
        }
        #endregion

        #region Methods
        public override object GetService(Type serviceType)
        {
            if (serviceType.Equals(typeof(IMouseListener)))
                return this;
            else if (serviceType.Equals(typeof(IHoverListener)))
                return this;
            else
                return null;
        }

        public virtual void MouseDown(MouseEventArgs e)
        {
            if(this.Rectangle.Contains(e.Location))
                this.Shape.ShapeColor = Color.Yellow;            
        }

        public void MouseMove(MouseEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(e.Location.ToString());
        }

        public virtual void MouseUp(MouseEventArgs e)
        {
            
        }
        #endregion

       

        #region IHoverListener Members
        public void MouseHover(MouseEventArgs e)
        {
           
        }
        private Color previousColor;
        private Cursor previousCursor;
        public void MouseEnter(MouseEventArgs e)
        {
                previousColor = this.Shape.ShapeColor;
                this.Shape.ShapeColor = Color.GreenYellow;
                previousCursor = Cursor.Current;                
                this.Shape.Model.RaiseOnCursorChange(Cursors.Hand);
        }

        public void MouseLeave(MouseEventArgs e)
        {
            this.Shape.ShapeColor = previousColor;
            this.Shape.Model.RaiseOnCursorChange(previousCursor);
        }

        #endregion
    }
}
