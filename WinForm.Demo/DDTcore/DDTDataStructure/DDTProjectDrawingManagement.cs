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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Netron.NetronLight;


namespace DDT
{
    public class DDTProjectDrawingManagement
    {
        #region Fields
        public DDTProject project;
       // List<DDTDiagram> diagrams;
       // List<DDTObject> objectList;
      //  List<DDTRelation> relationList;

        #endregion
        
        #region Constructor 
        public DDTProjectDrawingManagement() { }

        public DDTProjectDrawingManagement(DDTProject proj)
        {
            this.project = proj;
            //this.diagrams = proj.diagrams;
           // this.objectList = proj.objects;
           // this.relationList = proj.relations;

        }

        #endregion
        
        #region method

        //create a new diagram
 
        public DDTDiagram newDiagram(string name,DDT_Diagram_Type type)
        {
            string diagramName;
            if (name == null || name.Length == 0)
            {
                diagramName = "new_diagram";
            }
            else diagramName = name;

            DDT.DDTDiagram newDiagram = new DDT.DDTDiagram(diagramName,type);
            this.project.addDiagram(newDiagram);

            return newDiagram;
        }
 

        




        private static DDTDiagram getDDTDiagramById(int Id, List<DDTDiagram> list)
        {

            foreach (DDTDiagram temp in list)
            {
                if (temp.ID == Id)
                    return temp;
            }
            MessageBox.Show("DDTDiagram not found", "WARNING");
            return null;
        }
 

        public static void removeDDTObjectById(int Id, List<DDTObject> list)
        {

            foreach (DDTObject temp in list)
            {
                if (temp.ID == Id)
                {
                    list.Remove(temp);
                    return;
                }
            }
            MessageBox.Show("DDTObject not found");
        }


        public static void removeDDTRelationById(int Id, List<DDTRelation> list)
        {

            foreach (DDTRelation temp in list)
            {
                if (temp.ID == Id)
                {
                    list.Remove(temp);
                    return;
                }
            }
            MessageBox.Show("DDTRelation not found");
        }



        public static DDTObject getDDTObjectById(int Id, List<DDTObject> list)
        {

            foreach (DDTObject temp in list)
            {
                if (temp.ID == Id) 
                return temp;
            }
            MessageBox.Show("DDTObject not found");
            return null;

        }
        public static DDTRelation getDDTRelationById(int Id, List<DDTRelation> list)
        {

            foreach (DDTRelation temp in list)
            {
                if (temp.ID == Id)
                {
                    //MessageBox.Show("temp"+temp.from.objectId.ToString());
                    //MessageBox.Show("temp" + temp.to.objectId.ToString());
                    return temp;
                }
            }
            //MessageBox.Show("DDTRelation not found");
            return null;

        }

        public bool DDTRelationSaved(int Id)
        {
            if (getDDTRelationById(Id, project.relations) != null)
            {
                return true;
            }
            else return false;
           
        
        
        
        }
        /* Shape to Object, shouldn't be necessary
        public static  DDT.DDTObject DDTShapeToObject(Netron.NetronLight.IDDTObject objShape)
        {
           
        }
        */
         public static DDT.DDTObject CanvasToDDTObject(Netron.NetronLight.IDDTObject obj)
         {
             DDTObject temp;
             if (obj.GetType().Equals(typeof(Netron.NetronLight.CustomizedObject)))
             {
                 temp= new DDTObject(DDT_Obj_Type.CUSTOMIZED, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.DataStoreObject)))
             {
                 temp = new DDTObject(DDT_Obj_Type.DATASTORE, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.DataSinkObject)))
             {
                 temp = new DDTObject(DDT_Obj_Type.DATASINK, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.Terminator)))
             {
                 temp = new DDTObject(DDT_Obj_Type.TERMINATOR, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.ADTObject)))
             {
                 temp = new DDTObject(DDT_Obj_Type.ADT, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.CObject)))
             {
                 temp = new DDTObject(DDT_Obj_Type.COBJECT, obj.Text);
             }
             else if (obj.GetType().Equals(typeof(Netron.NetronLight.SMObject)))
             {
                 temp = new DDTObject(DDT_Obj_Type.SMOBJECT, obj.Text);
             }
             else
             {
                 MessageBox.Show("Invalid Object Type!!", "WARNING");
                 return null;
             }
             temp.ID = obj.ID;
             return temp;
 
         }



        public static Netron.NetronLight.IDDTObject DDTObjectToCanvas(DDT.DDTObject obj, System.Drawing.Point loc)
        {
            Netron.NetronLight.IDDTObject temp=null;
            switch (obj.type)
            {
                case DDT_Obj_Type.ADT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.ADTObject);
                    break;
                case DDT_Obj_Type.COBJECT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.CObject);
                    break;
                case DDT_Obj_Type.SMOBJECT:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.SMObject);
                    break;
                case DDT_Obj_Type.DATASTORE:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.DataStoreObject);
                    break;
                case DDT_Obj_Type.DATASINK:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.DataSinkObject);
                    break;
                case DDT_Obj_Type.TERMINATOR:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.Terminator);
                    break;
                case DDT_Obj_Type.CUSTOMIZED:
                    temp = (Netron.NetronLight.IDDTObject)Netron.NetronLight.ShapeFactory.GetShape(ShapeTypes.CustomizedObject);
                    break;
                default:
                    break;
            }
            if (temp != null)
            {
                temp.Text = obj.name;
                temp.ID = obj.ID;
                temp.Location = loc;
            }
           // MessageBox.Show(temp.ToString());
            return temp;
        }

        #region get Connection

        public static Netron.NetronLight.DDTConnection DDTRelationToCanvas(DDTRelation rel, Netron.NetronLight.Win.DiagramControl diagramControl)
        {
             

            Netron.NetronLight.DDTConnection connection;
            Netron.NetronLight.ConnectionType type;
            int fromId = rel.from.objectId;
            int toId = rel.to.objectId;
            int fromIndex;
            int toIndex;
            Netron.NetronLight.IDDTObject fromObj=null;
            Netron.NetronLight.IDDTObject toObj = null;
            IConnector fromConnector = null;
            IConnector toConnector = null;

         


            //get from and to objects
            foreach (Netron.NetronLight.IDDTDiagramEntity temp in diagramControl.controller.Model.Paintables)
            {
                
                
                if (temp.GetType().IsSubclassOf(typeof(Netron.NetronLight.IDDTObject)))
                {
                    if (((Netron.NetronLight.IDDTObject)temp).ID == fromId && fromObj == null)
                    {
                        fromObj = ((Netron.NetronLight.IDDTObject)temp);
                    }
                    if (((Netron.NetronLight.IDDTObject)temp).ID == toId && toObj == null)
                    {
                        toObj = ((Netron.NetronLight.IDDTObject)temp);
                    }
                    if (fromObj != null && toObj != null) { break; }
                }

            }

           


            fromConnector = getConnector(rel, ConnectorOrientation.FROM, fromObj);
            toConnector = getConnector(rel, ConnectorOrientation.TO, toObj);

             switch (rel.from.pos)
            {
                case Conn_Position.LEFT:
                    fromIndex = 1;
                    break;
                case Conn_Position.TOP:
                    fromIndex = 2;
                    break;
                case Conn_Position.RIGHT:
                    fromIndex = 3;
                    break;
                case Conn_Position.BOTTOM:
                    fromIndex = 4;
                    break;
                default:
                    fromIndex = 1;
                    break;
            }


             switch (rel.to.pos)
             {
                 case Conn_Position.LEFT:
                     toIndex = 1;
                     break;
                 case Conn_Position.TOP:
                     toIndex = 2;
                     break;
                 case Conn_Position.RIGHT:
                     toIndex = 3;
                     break;
                 case Conn_Position.BOTTOM:
                     toIndex = 4;
                     break;
                 default:
                     toIndex = 1;
                     break;
             }



           


            if (fromConnector == null || toConnector == null)
            {
                MessageBox.Show("DDTRelationToCanvas: the connection connects to a null DDTObject");
                return null;
            }
            
            type = getType(rel);
             
            connection = new Netron.NetronLight.DDTConnection(fromConnector, toConnector, diagramControl.controller.Model, type);
            
            connection.fromId = fromId;
            connection.toId = toId;
            connection.ID = rel.ID;
            connection.fromConnectorIndex = fromIndex;
            connection.toConnectorIndex = toIndex;

             
            
            /////////////////////////
            return connection;

        }



        private static Netron.NetronLight.ConnectionType getType(DDTRelation rel)
        {
            Netron.NetronLight.ConnectionType type;
            switch (rel.type)
            { 
                case DDT_Rel_Type.NORMAL:
                    type = Netron.NetronLight.ConnectionType.NORMAL;
                    break;
                case DDT_Rel_Type.SINGLEARROW:
                    type = Netron.NetronLight.ConnectionType.SINGLEARROW;
                    break;
                case DDT_Rel_Type.DOUBLEARROW:
                    type = Netron.NetronLight.ConnectionType.DOUBLEARROW;
                    break;
                case DDT_Rel_Type.ONETOONE:
                    type = Netron.NetronLight.ConnectionType.ONETOONE;
                    break;
                case DDT_Rel_Type.ONETOMANY:
                    type = Netron.NetronLight.ConnectionType.ONETOMANY;
                    break;
                case DDT_Rel_Type.MANYTOMANY:
                    type = Netron.NetronLight.ConnectionType.MANYTOMANY;
                    break;
                case DDT_Rel_Type.WIDEARROW:
                    type = Netron.NetronLight.ConnectionType.WIDEARROW;
                    break;
                case DDT_Rel_Type.DIAMONDARROW:
                    type = Netron.NetronLight.ConnectionType.DIAMONDARROW;
                    break;
                case DDT_Rel_Type.DASHEDARROW:
                    type = Netron.NetronLight.ConnectionType.DASHEDARROW;
                    break;
                default:
                    type = Netron.NetronLight.ConnectionType.SINGLEARROW;
                    break;            
            }
            return type;
        
        }


        private static IConnector getConnector(DDTRelation rel, ConnectorOrientation orientation, Netron.NetronLight.IDDTObject obj)
        {
          
            IConnector connector = null;
            Conn_Position temp;
            if (orientation == ConnectorOrientation.FROM)
                temp = rel.from.pos;
            else if (orientation == ConnectorOrientation.TO)
                temp = rel.to.pos;
            else return null;

            switch (temp)
            {
                case Conn_Position.LEFT:
                    connector = obj.connectorA;
                    break;
                case Conn_Position.TOP:
                    connector = obj.connectorB;
                    break;
                case Conn_Position.RIGHT:
                    connector = obj.connectorC;
                    break;
                case Conn_Position.BOTTOM:
                    connector = obj.connectorD;
                    break;
                default:
                    connector = obj.connectorC;
                    break;
            }

            return connector;
        }

       
        
        private enum ConnectorOrientation { FROM, TO }


        public static void addConnectionText(DDTRelation rel, Netron.NetronLight.DDTConnection connection, Netron.NetronLight.Win.DiagramControl diagramControl)
        {
            
            string from = rel.text.from;
            string mid = rel.text.middle;
            string to = rel.text.to;

            connection.setText(from, mid, to);
            //add 3 text blocks

            if (connection.Tfrom != null || connection.Tfrom.Length>0)
            {
                ConnectionText ctfrom = new ConnectionText(connection, TextPosition.From);
                diagramControl.controller.Model.AddShape(ctfrom);
            }
            if (connection.Tmid != null || connection.Tmid.Length > 0)
            {
                ConnectionText ctmid = new ConnectionText(connection, TextPosition.Mid);
                diagramControl.controller.Model.AddShape(ctmid);
            }
            if (connection.Tto != null || connection.Tto.Length > 0)
            {
                ConnectionText ctto = new ConnectionText(connection, TextPosition.To);
                diagramControl.controller.Model.AddShape(ctto);
            }
        }

        #endregion

        #region netron Connection to DDT Relation 
        public static DDT.DDT_Rel_Type getDDT_Rel_Type(Netron.NetronLight.ConnectionType type)
        {
            switch(type)
            {
                case Netron.NetronLight.ConnectionType.NORMAL:
                    return DDT_Rel_Type.NORMAL;
                case Netron.NetronLight.ConnectionType.SINGLEARROW:
                    return DDT_Rel_Type.SINGLEARROW;
                case Netron.NetronLight.ConnectionType.DOUBLEARROW:
                    return DDT_Rel_Type.DOUBLEARROW;
                case Netron.NetronLight.ConnectionType.ONETOONE:
                    return DDT_Rel_Type.ONETOONE;
                case Netron.NetronLight.ConnectionType.ONETOMANY:
                    return DDT_Rel_Type.ONETOMANY;
                case Netron.NetronLight.ConnectionType.MANYTOMANY:
                    return DDT_Rel_Type.MANYTOMANY;
                case Netron.NetronLight.ConnectionType.WIDEARROW:
                    return DDT_Rel_Type.WIDEARROW;
                case Netron.NetronLight.ConnectionType.DIAMONDARROW:
                    return DDT_Rel_Type.DIAMONDARROW;
                case Netron.NetronLight.ConnectionType.DASHEDARROW:
                    return DDT_Rel_Type.DASHEDARROW;
                default: return DDT_Rel_Type.NORMAL;
            }

        
        
        }


        public static DDT.DDTRelation DDTConnectionToRelationObj(Netron.NetronLight.DDTConnection conn)
        {
            
            DDT.DDT_Rel_Type type = getDDT_Rel_Type(conn.connectionType);
            DDT.DDTRelation temp = new DDT.DDTRelation(type,conn.fromId,conn.fromConnectorIndex,conn.toId,conn.toConnectorIndex,conn.fromText,conn.midText,conn.toText);
            temp.ID = conn.ID;
            return temp;      
        }



        #endregion

/// /////////////////////////////////////////////////////////////////////////////////////////////////////
//none static
        public IDDTElement getMappedElementByDDTObjectId(int objId)
        {
            int mappedId=-1;
            foreach (DDTObjectMap map in project.objectMaps)
            {
                if (objId == map.ddtOId)
                {
                    mappedId = map.oId;
                    break;
                }
            }
            foreach (CObject tempc in project.cObjects)
            {
                if (tempc.ID == mappedId)
                {
                    return tempc;
                }
            }

            foreach (ADTObject tempadt in project.aObjects)
            {
                if (tempadt.ID == mappedId)
                {

                    return tempadt;
                }
            }

            foreach (SMObject tempsm in project.smObjects)
            {
                if (tempsm.ID == mappedId)
                {

                    return tempsm;
                }
            }

            return null;
        }

        public void renameMappedObjectById(int mappedId, string name)
        {

            foreach (CObject tempc in project.cObjects)
            {
                if (tempc.ID == mappedId)
                {
                    tempc.name = name;
                    return;
                }
            }

            foreach (ADTObject tempadt in project.aObjects)
            {
                if (tempadt.ID == mappedId)
                {
                    tempadt.name = name;
                    return;
                }
            }

            foreach (SMObject tempsm in project.smObjects)
            {
                if (tempsm.ID == mappedId)
                {
                    tempsm.name = name;
                    return;
                }
            }

            MessageBox.Show("Mapped Object not found", "WARNING");
            return;

        }




        public DDTDiagram getDDTDiagramById(int diagramId)
        {
            return getDDTDiagramById(diagramId, project.diagrams);
        }

        //add object to project
        public void SaveObject(DDTObject obj)
        {
            this.project.objects.Add(obj);
        }

        #region Load diagram
        public void LoadDiagram(Netron.NetronLight.Win.DiagramControl diagramControl, DDTDiagram diagram)
        {
            diagramControl.controller.Model.Clear();

            foreach (DDTObjectReference objRef in diagram.ObjRefList)
            {
                //get DDTObject 

                DDTObject temp = getDDTObjectById(objRef.ID, project.objects);
                Netron.NetronLight.IDDTObject shape = DDTObjectToCanvas(temp, objRef.Location);
                 
                diagramControl.controller.Model.AddShape(shape);
                 
                //MessageBox.Show(shape.ToString());
              
            }

            
            foreach (int relId in diagram.RelIDList)
            {
                
                //MessageBox.Show("rel loaded: "+relId);
                //get DDTObject
                DDTRelation temp = getDDTRelationById(relId, project.relations);

                 

                //get connection
                Netron.NetronLight.DDTConnection connection = DDTRelationToCanvas(temp, diagramControl);

               

                //MessageBox.Show("rel loaded fin");
                connection.ID = temp.ID;
                
                //////////////////////////////////// 
                diagramControl.controller.Model.AddConnection(connection);

               

                //add text : from middle to
                if (temp.text != null)
                {
                    addConnectionText(temp, connection, diagramControl);          
                }

               

              // MessageBox.Show(temp.from.objectId.ToString());
               // MessageBox.Show(temp.to.objectId.ToString());
            }

            
             
           
        }
        
        #endregion


        #region save diagram
        public bool DDTObjectFound(Netron.NetronLight.IDDTObject tempObj)
        {
            foreach (DDTObject ddtobj in project.objects)
            {
                if (ddtobj.ID == tempObj.ID)
                    return true;
            }

            return false;
        }

        public bool DDTObjectFound(int tempObjID)
        {
            foreach (DDTObject ddtobj in project.objects)
            {
                if (ddtobj.ID == tempObjID)
                    return true;
            }

            return false;
        }

        public bool DDTRelationFound(int relID)
        {
            foreach (DDTRelation tmprel in project.relations)
            {
                if (tmprel.ID == relID)
                    return true;
            }

            return false;
        }
        

        public void removeDDTObjectById(int id)
        {
            foreach (DDTObject tmp in project.objects)
            { 
              if(tmp.ID==id)
              {
                  project.objects.Remove(tmp);
                  return;
              }
            }
            MessageBox.Show("DDTObject not found");
            return;
        }


        public void removeDDTRelationById(int id)
        {
            foreach (DDTRelation tmp in project.relations)
            {
                if (tmp.ID == id)
                {
                    project.relations.Remove(tmp);
                    return;
                }
            }
            MessageBox.Show("DDTRelation not found");
            return;
        }

        public string getDDTObjectNameById(int id)
        {
            return getDDTObjectById(id, project.objects).name; 
        }

        private bool DDTRelationFound(Netron.NetronLight.DDTConnection tempconn)
        {
            foreach (DDTRelation ddtrel in project.relations)
            {
                if (ddtrel.ID == tempconn.ID)
                    return true;
            }

            return false;
        }


        public void updateDDTObject(Netron.NetronLight.IDDTObject obj)
        {
            //change Object name
            getDDTObjectById(obj.ID, project.objects).name = obj.Text;
        }

        public void updateDDTRelation(Netron.NetronLight.DDTConnection conn)
        {
            DDT.DDTRelation DDTrel = getDDTRelationById(conn.ID, project.relations);
            //update connectors and texts
            DDTrel.from = new DDTConnector(conn.fromId, conn.fromConnectorIndex);
            DDTrel.to = new DDTConnector(conn.toId, conn.toConnectorIndex);
            DDTrel.text = new DDTRelationTexts(conn.fromText, conn.midText, conn.toText);
        }
        
        //assume this Diagram already has a name and type
        //public DDTDiagram(string name, DDT_Diagram_Type type, List<int> ObjIDList, List<int> RelIDList)
        public void saveDiagram(Netron.NetronLight.Win.DiagramControl diagramControl, DDTDiagram diagram)
        {

            List<int> objectListBefore = new List<int>();
            List<int> relListBefore = new List<int>();
            List<int> objectListCurrent = new List<int>();
            List<int> relListCurrent = new List<int>();

            foreach (DDTObjectReference objref in diagram.ObjRefList)
            {
                objectListBefore.Add(objref.ID);
            }
            foreach (int rel in diagram.RelIDList)
            {
                relListBefore.Add(rel);
            }


            diagram.ObjRefList.Clear();
            diagram.RelIDList.Clear();

            foreach (Netron.NetronLight.IDDTDiagramEntity tempObj in diagramControl.controller.Model.Paintables)
            {
                if (tempObj.GetType().IsSubclassOf(typeof(Netron.NetronLight.IDDTObject)))
                {
                    //if it's the first time see an Smallobject, assign an ID and add to list
                    if (tempObj.GetType().IsSubclassOf(typeof(Netron.NetronLight.SmallObject)))
                    {
                        if (!DDTObjectFound((Netron.NetronLight.IDDTObject)tempObj))
                        {
                            //MessageBox.Show("SmallObject:" +((Netron.NetronLight.SmallObject)tempObj).ID );
                            //add to obj list
                            this.project.objects.Add(CanvasToDDTObject((Netron.NetronLight.IDDTObject)tempObj));
                        }
                        updateDDTObject((Netron.NetronLight.IDDTObject)tempObj);
                    }
                    else
                    {
                       updateDDTObject((Netron.NetronLight.IDDTObject)tempObj);
                     
                    }
                    diagram.ObjRefList.Add(new DDTObjectReference(((Netron.NetronLight.IDDTObject)tempObj).ID, ((Netron.NetronLight.IDDTObject)tempObj).Location));
                }
            }

             
            foreach (Netron.NetronLight.IDDTDiagramEntity tempRel in diagramControl.controller.Model.Paintables)
            {
                if (tempRel.GetType().Equals(typeof(Netron.NetronLight.DDTConnection)))
                {
                    //if first created Netron connection, save it. else just update.
                    //if (((Netron.NetronLight.DDTConnection)tempRel).ID <= 0)
                    if(!DDTRelationFound((Netron.NetronLight.DDTConnection)tempRel))
                    { 
                        ((Netron.NetronLight.DDTConnection)tempRel).ID = DDT.staticId.getid();
                        DDT.DDTRelation rel = DDTConnectionToRelationObj((Netron.NetronLight.DDTConnection)tempRel);
                        rel.diagramType = diagram.type;
                        //rel.parentDiagramID = diagram.ID;
                        this.project.relations.Add(rel);
                    }
                    else
                    {

                         updateDDTRelation((Netron.NetronLight.DDTConnection)tempRel);
                         
                    }
                       //MessageBox.Show("new DDTRelation saved:"+rel.ID);
                       //MessageBox.Show("Obj " + tempRel.ToString());
  
                    diagram.RelIDList.Add(((Netron.NetronLight.DDTConnection)tempRel).ID);
                }
            }


            //remove other objects and relations in the project when they are removed from the canvas
            foreach (DDTObjectReference objref in diagram.ObjRefList)
            {
                objectListCurrent.Add(objref.ID);
            }
            foreach (int rel in diagram.RelIDList)
            {
                relListCurrent.Add(rel);
            }

            //if an Other object is not in the current objectreference, then delete it 
            foreach (int tmpobj in objectListBefore)
            {
                if (!objectListCurrent.Contains(tmpobj))
                {
                    DDTObject objToDel = getDDTObjectById(tmpobj, project.objects);
                    if (!objToDel.type.Equals(DDT_Obj_Type.ADT) && !objToDel.type.Equals(DDT_Obj_Type.COBJECT) && !objToDel.type.Equals(DDT_Obj_Type.SMOBJECT))
                    {
                        project.objects.Remove(objToDel);
                       
                    }   
                }
            }
            foreach (int tmprel in relListBefore)
            {
                if (!relListCurrent.Contains(tmprel))
                {
                    DDTRelation RelToDel = getDDTRelationById(tmprel, project.relations);
                    project.relations.Remove(RelToDel);
                }
            }


            foreach(DDTRelation tmpRel in project.relations)
            {
                if (!DDTObjectFound(tmpRel.from.objectId) || !DDTObjectFound(tmpRel.to.objectId))
                {
                    project.relations.Remove(tmpRel); 
                }
             }

        }
 




        public void saveDiagramsInTabControl(TabControl tabControl)
        {
            foreach (System.Windows.Forms.TabPage tp in tabControl.TabPages)
            {
                if (tp.Controls[0] != null)
                {
                    Netron.NetronLight.Win.DiagramControl diagramControl = (Netron.NetronLight.Win.DiagramControl)tp.Controls[0];
                    DDTDiagram diagram;
                    if (tp.GetType().Equals(typeof(DDT.DDTTabPage)))
                    {
                        diagram = getDDTDiagramById(((DDT.DDTTabPage)tp).ID, this.project.diagrams);
                    }
                    else continue;

                    this.saveDiagram(diagramControl, diagram);

                }
            } 
        }


        #endregion

        public static string getObjectTypeString(DDT.DDTObject obj)
        {
            switch (obj.type)
            { 
                case DDT_Obj_Type.ADT:
                    return "ADTObject";
                case DDT_Obj_Type.COBJECT:
                    return "CObject";
                case DDT_Obj_Type.SMOBJECT:
                    return "SMObject";
                case DDT_Obj_Type.DATASTORE:
                    return "DataStoreObject";
                case DDT_Obj_Type.DATASINK:
                    return "DataSinkObject";
                case DDT_Obj_Type.TERMINATOR:
                    return "Terminator";
                case DDT_Obj_Type.CUSTOMIZED:
                    return "CustomizedObject";
                default: return "";         
            }
        
        
        }

        public void removeDiagram(DDTDiagram diagram)
        {
            foreach (int relID in diagram.RelIDList)
            {
                removeDDTRelationById(relID, project.relations);
            }
            foreach (DDTObjectReference objr in diagram.ObjRefList)
            {
                DDTObject obj = getDDTObjectById(objr.ID, project.objects);
                if (obj.type != DDT_Obj_Type.ADT && obj.type != DDT_Obj_Type.COBJECT && obj.type != DDT_Obj_Type.SMOBJECT)
                {
                    removeDDTObjectById(objr.ID, project.objects);
                }            
            }
            this.project.diagrams.Remove(diagram);
        }


        #region ORV

        public List<DDT.DDTDiagram> getORV(int objID)
        {
            List<DDT.DDTDiagram> ORVList = new List<DDTDiagram>();
            double max = 4.0; //6 relations a group
            DDT.DDTObject obj = getDDTObjectById(objID, project.objects);

            string diaName = obj.name + "_ORV";
          

            List<DDT.DDTRelation> relList = new List<DDTRelation>();

            //get all ERD relations related to the object we want
            foreach (DDTRelation rel in project.relations)
            {
                if (rel.diagramType == DDT_Diagram_Type.ERD)
                {

                    if (rel.from.objectId == objID || rel.to.objectId == objID)
                    {
                        relList.Add(rel);
                    }
                }
            }
   
            //6+1 obj in a group at maximum
            int groups = (int)Math.Ceiling((double)(relList.Count) / max);

           

            int remainder = relList.Count%(int)max; //last group has such many relations
           
            int i;
            int secondObjID;
 
            DDTRelation tmpRel;
            DDTObject tmpObj;
            DDT.DDT_Obj_Type t;
            //get diagram for each group except the last group
            if (groups >= 2)
            {
 
                for (i = 1; i < groups; i++)
                {
                    string diaNamei = diaName + "_" + i.ToString();
                    DDT.DDTDiagram diagram = new DDT.DDTDiagram(diaNamei, DDT_Diagram_Type.ORV);

                    //locate the first object
                    diagram.ObjRefList.Add(new DDTObjectReference(objID, new Point(50, 210)));
                    //get 6 relations for each group
                    for (int k = (int)max * (i - 1); k < (int)max * i; k++)
                    {                        
                        if (relList[k].from.objectId == objID && relList[k].to.objectId != objID)
                        { 
                            secondObjID = relList[k].to.objectId;
                        }
                        else if (relList[k].to.objectId == objID && relList[k].from.objectId != objID)
                        {
                            secondObjID = relList[k].from.objectId;
                        }
                        else {   //it's a link to itself
                            tmpRel = getDDTRelationById(relList[k].ID,project.relations).deepClone();
                            tmpRel.diagramType = DDT_Diagram_Type.ORV;
                            project.relations.Add(tmpRel);
                            diagram.RelIDList.Add(tmpRel.ID);
                            continue; 
                        }
                         

                        t = getDDTObjectById(secondObjID, project.objects).type;
                        if (t == DDT_Obj_Type.ADT || t == DDT_Obj_Type.COBJECT || t == DDT_Obj_Type.SMOBJECT)
                        {
                            ;
                        }
                        else
                        {//if not 3 main type. then create need object and add to list
                            tmpObj = getDDTObjectById(secondObjID, project.objects).deepClone();
                            project.objects.Add(tmpObj);
                            secondObjID = tmpObj.ID;
                        }

                         

                        Point p = getLocator(k);
                        //add relations in group i to diagram i.
                        /*
                         * change connector position
                         */     
                        tmpRel = getDDTRelationById(relList[k].ID, project.relations).deepClone();
                        tmpRel.diagramType = DDT_Diagram_Type.ORV;
                        //arrange connectors
                        if (tmpRel.from.objectId == objID)
                        {
                            tmpRel.from.pos = DDT.Conn_Position.RIGHT;
                            tmpRel.to.pos = DDT.Conn_Position.LEFT;

                            //change to the second object
                            tmpRel.to.objectId = secondObjID;
                        }
                        else
                        {
                            tmpRel.from.pos = DDT.Conn_Position.LEFT;
                            tmpRel.to.pos = DDT.Conn_Position.RIGHT;
                            tmpRel.from.objectId = secondObjID;
                        }



                        project.relations.Add(tmpRel);
                        diagram.RelIDList.Add(tmpRel.ID);




                        diagram.ObjRefList.Add(new DDTObjectReference(secondObjID, p));

                    }
                    ORVList.Add(diagram); 

                }


                //last diagram
                
                string lastDiaName = diaName + "_" + groups.ToString();
                DDT.DDTDiagram diagramLast = new DDT.DDTDiagram(lastDiaName, DDT_Diagram_Type.ORV);
                diagramLast.ObjRefList.Add(new DDTObjectReference(objID, new Point(50, 210)));
                for (i = remainder; i > 0; i--)
                {
                    int index = relList.Count - i;

                    if (relList[index].from.objectId == objID && relList[index].to.objectId != objID)
                    {
                        secondObjID = relList[index].to.objectId;
                    }
                    else if (relList[index].to.objectId == objID && relList[index].from.objectId != objID)
                    {
                        secondObjID = relList[index].from.objectId;
                    }
                    else
                    {

                        tmpRel = getDDTRelationById(relList[index].ID, project.relations).deepClone();
                        tmpRel.diagramType = DDT_Diagram_Type.ORV;
                        project.relations.Add(tmpRel);
                        diagramLast.RelIDList.Add(tmpRel.ID);
                        continue;
                    }


                    t = getDDTObjectById(secondObjID, project.objects).type;
                    if (t == DDT_Obj_Type.ADT || t == DDT_Obj_Type.COBJECT || t == DDT_Obj_Type.SMOBJECT)
                    {
                        ;
                    }
                    else
                    {//if not 3 main type. then create need object and add to list
                        tmpObj = getDDTObjectById(secondObjID, project.objects).deepClone();
                        project.objects.Add(tmpObj);
                        secondObjID = tmpObj.ID;
                    }

                    Point p1 = getLocator(i);

/*
 * change connector position
 */ 
                    tmpRel = getDDTRelationById(relList[index].ID, project.relations).deepClone();
                    tmpRel.diagramType = DDT_Diagram_Type.ORV;
                    if (tmpRel.from.objectId == objID)
                    {
                        tmpRel.from.pos = DDT.Conn_Position.RIGHT;
                        tmpRel.to.pos = DDT.Conn_Position.LEFT;
                        //change to the second object
                        tmpRel.to.objectId = secondObjID;
                    }
                    else
                    {
                        tmpRel.from.pos = DDT.Conn_Position.LEFT;
                        tmpRel.to.pos = DDT.Conn_Position.RIGHT;
                        tmpRel.from.objectId = secondObjID;
                    }
                    project.relations.Add(tmpRel);
                    diagramLast.RelIDList.Add(tmpRel.ID);



                    diagramLast.ObjRefList.Add(new DDTObjectReference(secondObjID, p1));
                }
                ORVList.Add(diagramLast); 
            }
                //if only 1 group
            else if (groups == 1)
            {
                if (remainder == 0) remainder = (int)max;
                string lastDiaName = diaName + "_" + groups.ToString();
                DDT.DDTDiagram diagramLast = new DDT.DDTDiagram(lastDiaName, DDT_Diagram_Type.ORV);
                diagramLast.ObjRefList.Add(new DDTObjectReference(objID, new Point(50, 210)));
                for (i = remainder; i > 0; i--)
                {
                    int index = relList.Count - i;

                    if (relList[index].from.objectId == objID && relList[index].to.objectId != objID)
                    {
                        secondObjID = relList[index].to.objectId;
                    }
                    else if (relList[index].to.objectId == objID && relList[index].from.objectId != objID)
                    {
                        secondObjID = relList[index].from.objectId;
                    }
                    else
                    {
                        tmpRel = getDDTRelationById(relList[index].ID, project.relations).deepClone();
                        tmpRel.diagramType = DDT_Diagram_Type.ORV;
                        project.relations.Add(tmpRel);
                        diagramLast.RelIDList.Add(tmpRel.ID);
                        continue;
                    }
                    
                    t = getDDTObjectById(secondObjID, project.objects).type;
                    if (t == DDT_Obj_Type.ADT || t == DDT_Obj_Type.COBJECT || t == DDT_Obj_Type.SMOBJECT)
                    {
                        ;
                    }
                    else
                    {//if not 3 main type. then create need object and add to list
                        tmpObj = getDDTObjectById(secondObjID, project.objects).deepClone();
                        project.objects.Add(tmpObj);
                        secondObjID = tmpObj.ID;
                    }

                    Point p1 = getLocator(i);
                    /*
                     * change connector position
                     */ 
                    tmpRel = getDDTRelationById(relList[index].ID, project.relations).deepClone();
                    tmpRel.diagramType = DDT_Diagram_Type.ORV;
                    if (tmpRel.from.objectId == objID)
                    {
                        tmpRel.from.pos = DDT.Conn_Position.RIGHT;
                        tmpRel.to.pos = DDT.Conn_Position.LEFT;
                        //change to the second object
                        tmpRel.to.objectId = secondObjID;
                    }
                    else
                    {
                        tmpRel.from.pos = DDT.Conn_Position.LEFT;
                        tmpRel.to.pos = DDT.Conn_Position.RIGHT;
                        tmpRel.from.objectId = secondObjID;
                    }
                    project.relations.Add(tmpRel);
                    diagramLast.RelIDList.Add(tmpRel.ID);


                    diagramLast.ObjRefList.Add(new DDTObjectReference(secondObjID, p1));
                }
                ORVList.Add(diagramLast);
            } 
            else                
            { 
                    MessageBox.Show("No Object Relation found!!", "WARNING"); return null; 
            }
            

                //add last Diagram
              
     
            return ORVList;
        }


        private Point getLocator(int k)
        {
            int i = k % 6;
            switch (i)
            { 
                case 0:
                    return new Point(200, 50);
                case 1:
                    return new Point(400,150);
                case 2:
                    return new Point(400, 280);
                case 3:
                    return new Point(400, 50);
                case 4:
                    return new Point(400, 400);
                case 5:
                    return new Point(200, 400);
                default:
                    return new Point(50, 50);
            }
        }
 



        #endregion
        #endregion

    }
}
