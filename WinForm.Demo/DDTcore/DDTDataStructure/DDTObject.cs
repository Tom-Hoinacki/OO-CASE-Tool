/*
 * CECS 543 Spring 2011
 * Team Number 1:
 *   Philip Brack(project Manager)
 *   Tom Hoinacki
 *   Ayan Kar
 *   Ravi Mahana
 *   Michael Ngo
 *   Panos Zoumpoulidis
 *   Yang Zhao
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace DDT       
{
    public class DDTObject : IDDTElement
    {
        #region Feilds 

        public DDT_Obj_Type type;//type 
        public string name;//object name. will be appear on the shape;
        //location
        //public System.Drawing.Point location;
        public List<DDT_Obj_Property> properties;//properties
        public List<DDT_Obj_Event> events;//not sure if we have this
        #endregion

        #region construct
        public DDTObject() : base() { }
        public DDTObject(DDT_Obj_Type type, string name,  List<DDT_Obj_Property> properties, List<DDT_Obj_Event> events)
            : base()
        {
            //this.location = loc;
            this.type = type;
            this.name = name;
            this.properties = properties;
            this.events = events;
        }

        public DDTObject(DDT_Obj_Type type, string name)
            : base()
        {
            //this.location = loc;
            this.type = type;
            this.name = name;
        }

        #endregion

        #region method
        public DDTObject deepClone() //not really deep
        {
            DDTObject newObj = new DDTObject(this.type, this.name, this.properties, this.events);
            return newObj;
        }

        public Netron.NetronLight.IDDTObject toNetron()
        {
            Netron.NetronLight.IDDTObject temp;
            DDT_Obj_Type type=this.type;
            switch(type)
            {
                case DDT_Obj_Type.ADT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.ADTObject);
                    break;
                case DDT_Obj_Type.COBJECT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.CObject);
                    break;
                case DDT_Obj_Type.SMOBJECT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.SMObject);
                    break;
                case DDT_Obj_Type.CUSTOMIZED:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.CustomizedObject);
                    break;
                case DDT_Obj_Type.DATASTORE:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.DataStoreObject);
                    break;
                case DDT_Obj_Type.DATASINK:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.DataSinkObject);
                    break;
                case DDT_Obj_Type.TERMINATOR:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.Terminator);
                    break;                
                default:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(Netron.NetronLight.ShapeTypes.CustomizedObject);
                    break;
            }
            //show the name on the shape
            temp.Text = this.name;

            return temp;
        }

        public override string ToString()
        {
            return name;
        }

        #endregion




    }
    public enum DDT_Obj_Type
    { 
        ADT,
        COBJECT,
        SMOBJECT,
        DATASTORE,
        DATASINK,
        TERMINATOR,
        CUSTOMIZED
        //maybe more
    }

    public class DDT_Obj_Property
    {
        #region Feilds
        public string propertyName;
        public string propertydomain;  
        public string propertyValue;
        #endregion
        public DDT_Obj_Property() { }
        public DDT_Obj_Property (string name, string domain, string value)
        {
            propertyName = name;
            propertydomain = domain;
            propertyValue = value;
        
        }

    }

    public class DDT_Obj_Event //not sure
    {
        #region Feilds
        public string eventName;
        public string eventDescription;
        #endregion

        public DDT_Obj_Event() { }
        public DDT_Obj_Event(string name, string desc)
        {
            eventName = name;
            eventDescription = desc;
        }
    }
}
