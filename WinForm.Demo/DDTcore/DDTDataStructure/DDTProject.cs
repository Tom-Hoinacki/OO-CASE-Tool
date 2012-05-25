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
    public class DDTProject   
    {
        #region Feilds
        public string name;//project name 
        public List<DDTDiagram> diagrams;
        public List<DDTObject> objects;
        public List<DDTRelation> relations;
        public List<CObject> cObjects;
        public List<ADTObject> aObjects;
        public List<SMObject> smObjects;
        public List<DDTObjectMap> objectMaps;
        #endregion

        #region contructor
        
        public DDTProject()
        {
            this.name = "";
            this.diagrams = new List<DDTDiagram>();
            this.objects = new List<DDTObject>();
            this.relations = new List<DDTRelation>();
            this.cObjects = new List<CObject>();
            this.aObjects = new List<ADTObject>();
            this.smObjects = new List<SMObject>();
            this.objectMaps = new List<DDTObjectMap>();
        }

        public DDTProject(string name)
        {
            this.name = name;
            this.diagrams = new List<DDTDiagram>();
            this.objects = new List<DDTObject>();
            this.relations = new List<DDTRelation>();
            this.cObjects = new List<CObject>();
            this.aObjects = new List<ADTObject>();
            this.smObjects = new List<SMObject>();
            this.objectMaps = new List<DDTObjectMap>();
        }


        public DDTProject(string name, List<DDTDiagram> diagrams, List<DDTObject> objects, List<DDTRelation> relations)
        {
            this.name = name;
            this.diagrams = diagrams;
            this.objects = objects;
            this.relations = relations;
        }
        
        
        #endregion

        
        #region methods

        public void addDiagram(DDTDiagram diagram)
        {
            this.diagrams.Add(diagram);
        }

        public void addDiagramList(List<DDTDiagram> diagrams)
        {
            this.diagrams = diagrams;
        }

        public void addObject(DDTObject obj)
        {
            this.objects.Add(obj);
        }

        public void addObjectList(List<DDTObject> objs)
        {
            this.objects = objs;
        }

        public void addRelation(DDTRelation rel)
        {
            this.relations.Add(rel);
        }

        public void addRelationList(List<DDTRelation> rel)
        {
            this.relations = rel;
        }

        public void rename(string name)
        { this.name = name; }




        #endregion

        #region These methods are for Ayan to update the project for C,ADT,SM Objects.

        /// <summary>
        /// When adding a new CObject we need to add a drawable oject as well.
        /// The map will allows up to synchronized them.
        /// </summary>
        /// <param name="o"></param>
        public void addNewCObject(CObject o)
        {
            DDTObject newObject = new DDTObject(DDT_Obj_Type.COBJECT, o.name);
            cObjects.Add(o);
            objects.Add(newObject);
            
            objectMaps.Add(new DDTObjectMap(o.ID, newObject.ID));

        }
        /// <summary>
        /// When adding a new ADTObject we need to add a drawable oject as well.
        /// The map will allows up to synchronized them.
        /// </summary>
        /// <param name="o"></param>
        public void addNewADTObject(ADTObject o)
        {
            DDTObject newObject = new DDTObject(DDT_Obj_Type.ADT, o.name);
            aObjects.Add(o);
            objects.Add(newObject);
            objectMaps.Add(new DDTObjectMap(o.ID, newObject.ID));

        }
        /// <summary>
        /// When adding a new SMObject we need to add a drawable oject as well.
        /// The map will allows up to synchronized them.
        /// </summary>
        /// <param name="o"></param>
        public void addNewSMObject(SMObject o)
        {
            DDTObject newObject = new DDTObject(DDT_Obj_Type.SMOBJECT, o.name);
            smObjects.Add(o);
            objects.Add(newObject);
            objectMaps.Add(new DDTObjectMap(o.ID, newObject.ID));

        }

        public int getDDTObjectFromObjectID(int id)
        {
            int ddtID = 0;


            foreach (DDTObjectMap current in objectMaps)
            {
                if (current.oId == id)
                {
                    ddtID = current.ddtOId;
                    return ddtID;
                }

            }
            return ddtID;
        }


        public int getCObjectFromDDTObjectID(int ddtid)
        {
            int cId = 0;


            foreach (DDTObjectMap current in objectMaps)
            {
                if (current.ddtOId == ddtid)
                {
                    cId = current.oId;
                    return cId;
                }

            }
            return cId;
        }



        /// <summary>
        /// method to get a C object by id.
        /// Null is returned if the C object does
        /// not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CObject getCObject(int id)
        {
            CObject returned = null;
            foreach (CObject c in cObjects)
            {
                if (c.ID == id)
                {
                    returned = c;
                }
            }
            return returned;
        }

        /// <summary>
        /// method to get an ADT object by id.
        /// Null is returned if the ADT object does
        /// not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ADTObject getADTObject(int id)
        {
            ADTObject returned = null;
            foreach (ADTObject c in aObjects)
            {
                if (c.ID == id)
                {
                    returned = c;
                }
            }
            return returned;
        }

        /// <summary>
        /// method to get an SM object by id.
        /// Null is returned if the SM object does
        /// not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SMObject getSMObject(int id)
        {
            SMObject returned = null;
            foreach (SMObject c in smObjects)
            {
                if (c.ID == id)
                {
                    returned = c;
                }
            }
            return returned;
        }

        /// <summary>
        /// method to get a relation object by id.
        /// Null is returned if the relation object does
        /// not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DDTRelation getDDTRelation(int id)
        {
            DDTRelation returned = null;
            foreach (DDTRelation r in relations)
            {
                if (r.ID == id)
                {
                    returned = r;
                }
            }
            return returned;
        }

        /// <summary>
        /// method to get a DDTObject object by id.
        /// Null is returned if the DDTObject object does
        /// not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DDTObject getDDTObject(int id)
        {
            DDTObject returned = null;
            foreach (DDTObject d in objects)
            {
                if (d.ID == id)
                {
                    returned = d;
                }
            }
            return returned;
        }

        /// <summary>
        /// To remove a DDTObject you first need to remove
        /// all of the references to it.
        /// </summary>
        /// <param name="id"></param>
        public void removeDDTObject(int id)
        {
            List<int> relationsToRemoveLater = new List<int>();
            // remove all references in diagram.
            foreach (DDTDiagram d in diagrams)
            {
                foreach (int rId in d.RelIDList)
                {
                    //DDTRelation r = relations.
                    DDTRelation r = getDDTRelation(rId);
                    if (r.from.objectId == id || r.to.objectId == id)
                    {
                        d.RelIDList.Remove(rId);
                        relationsToRemoveLater.Add(rId);
                        break; // might need this...
                    }
                }
            }

            // remove things from the project itself.
            foreach (int element in relationsToRemoveLater)
            {
                DDTRelation r = getDDTRelation(element);
                relations.Remove(r);
            }
            DDTObject objectToRemove = getDDTObject(id);
            objects.Remove(objectToRemove);
        }
        /// <summary>
        /// When removing an object we have to also remove the drawable object
        /// and any relations in a diagram to it.
        /// </summary>
        /// <param name="o">object to remove </param>
        public void removeCObject(CObject o)
        {
            int id = 0;
            foreach (DDTObjectMap current in objectMaps)
            {
                if (current.oId == o.ID)
                {
                    id = current.ddtOId;
                }
            }
            removeDDTObject(id);

            cObjects.Remove(o);


        }
        /// <summary>
        /// When removing an object we have to also remove the drawable object
        /// and any relations in a diagram to it.
        /// </summary>
        /// <param name="o">object to remove </param>
        public void removeADTObject(ADTObject o)
        {
            int id = 0;
            foreach (DDTObjectMap current in objectMaps)
            {
                if (current.oId == o.ID)
                {
                    id = current.ddtOId;
                }
            }
            removeDDTObject(id);

            aObjects.Remove(o);


        }
        /// <summary>
        /// When removing an object we have to also remove the drawable object
        /// and any relations in a diagram to it.
        /// </summary>
        /// <param name="o">object to remove </param>
        public void removeSMObject(SMObject o)
        {
            int id = 0;
            foreach (DDTObjectMap current in objectMaps)
            {
                if (current.oId == o.ID)
                {
                    id = current.ddtOId;
                }
            }
            removeDDTObject(id);

            smObjects.Remove(o);


        }



        #endregion
    }
}
