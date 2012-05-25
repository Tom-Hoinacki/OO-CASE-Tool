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
    public class DDTDiagram : IDDTElement
    {
        #region Feilds
        public string name;//diagram name
        public DDT_Diagram_Type type;//diagram Type  
        public List<DDTObjectReference> ObjRefList;

        public List<int> RelIDList;//list of DDTObject id and DDTRelation id
        #endregion

        #region constructor
        public DDTDiagram() : base() { }
        public DDTDiagram(string name, DDT_Diagram_Type type, List<DDTObjectReference> ObjIDList, List<int> RelIDList)
            : base()
        {
            this.name = name;
            this.type = type;
            this.ObjRefList = ObjIDList;
            this.RelIDList = RelIDList;       
        }

        public DDTDiagram(string name, DDT_Diagram_Type type)
        {
            this.name = name;
            this.type = type;
            this.ObjRefList = new List<DDTObjectReference>();
            this.RelIDList = new List<int>();  
        }
        #endregion


    }
    public enum DDT_Diagram_Type
    { 
        ERD,
        CFD,
        DFD,
        DMD,
        ORV,
        CH//class hierarchy
    }

    public class DDTObjectReference
    {
       public int ID;
       public System.Drawing.Point Location;

       public DDTObjectReference() { }
        public DDTObjectReference(int id, System.Drawing.Point loc)
        {
            this.ID = id;
            this.Location = loc;
        }
    
    }
}
