using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    public abstract class IDDTObject1 : ComplexShapeBase,IDDTDiagramEntity
    {
        #region Fields
        //private Rectangle mTextRectangle;
       protected IConnector cBottom = new Connector(new Point());
       protected IConnector cLeft = new Connector(new Point());
       protected IConnector cRight = new Connector(new Point());
       protected IConnector cTop = new Connector(new Point());
       public int ID;
 
        #endregion
      /* public Rectangle TextRectangle
       {
           get
           {
               return mTextRectangle;
           }
           set
           {
               mTextRectangle = value;
           }
       }*/
       public IDDTObject1(IModel model)
           : base(model) { 
        //mTextRectangle = Rectangle; 
       }

       public IDDTObject1()
           : base() { 
           //mTextRectangle = Rectangle; 
       }   

        public IConnector connectorA{

            get { return cLeft; }
            set { cLeft = value; }
    
        }
        public IConnector connectorB
        {
            get { return cTop; }
            set { cTop = value; }
        }

        public IConnector connectorC
        {
            get { return cRight; }
            set { cRight = value; }
        }
        public IConnector connectorD
        {
            get { return cBottom; }
            set { cBottom = value; }
        }
        public string getText() { return Text; }
        public Point getLocation() { return this.Rectangle.Location; }
        protected virtual void setTextFormat() { }

        protected virtual void setTextFont() { }

        protected virtual void setRectangleSize() { }

        public virtual void OnRemove() { }
        public virtual void OnDoubleClick(MouseEventArgs e){}
        public virtual void OnRightDoubleClick(MouseEventArgs e){}
        public virtual void OnRightClick(MouseEventArgs e){}
     
    }
}
