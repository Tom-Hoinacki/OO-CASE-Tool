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
    public class DDTRelation : IDDTElement   
    {
        #region Feilds
        public DDT_Rel_Type type;
        public DDTConnector from;
        public DDTConnector to;
        public DDTRelationTexts text;
        public DDT_Diagram_Type diagramType=DDT_Diagram_Type.ERD;//default
        public int parentDiagramID=0;
        #endregion                   
         

        #region constructor
        public DDTRelation() { }

        public DDTRelation(DDT_Rel_Type type, DDTConnector from, DDTConnector to, DDTRelationTexts text)
            : base()
        {
            this.type = type;
            this.from = from;
            this.to = to;
            if(text!=null)
            this.text = text;
        }

        public DDTRelation(int type, int objfrom,int f, int objto,int t, string ftext, string mtext,string ttext)
            : base()
        {
            this.type = getDDT_Rel_Type(type);
            this.from = new DDTConnector(objfrom, f);
            this.to = new DDTConnector(objto, t);
            this.text = new DDTRelationTexts(ftext, mtext, ttext);
        }

        public DDTRelation(DDT_Rel_Type type, int objfrom, int f, int objto, int t, string ftext, string mtext, string ttext)
            : base()
        {
            this.type = type;
            this.from = new DDTConnector(objfrom, f);
            this.to = new DDTConnector(objto, t);
            this.text = new DDTRelationTexts(ftext, mtext, ttext);
        }

        #endregion

        public DDTRelation deepClone()
        {

            DDTRelation newRel = new DDTRelation(type, this.from.clone(), this.to.clone(), this.text.clone());
            newRel.diagramType = this.diagramType;
            newRel.parentDiagramID = this.parentDiagramID;
            return newRel;   
        }
        public DDT_Rel_Type getDDT_Rel_Type(int i)
        {
            switch (i)
            { 
                case 0:
                    return DDT_Rel_Type.NORMAL;
                case 1:
                    return DDT_Rel_Type.SINGLEARROW;
                case 2:
                    return DDT_Rel_Type.DOUBLEARROW;
                case 3:
                    return DDT_Rel_Type.ONETOONE;
                case 4:
                    return DDT_Rel_Type.ONETOMANY;
                case 5:
                    return DDT_Rel_Type.WIDEARROW;
                case 6:
                    return DDT_Rel_Type.DIAMONDARROW;
                case 7:
                    return DDT_Rel_Type.DASHEDARROW;
                default:
                    return DDT_Rel_Type.SINGLEARROW;
            }
        }

    } 
    


    public enum DDT_Rel_Type
    {
        NORMAL, 
        SINGLEARROW, 
        DOUBLEARROW, 
        ONETOONE, 
        ONETOMANY, 
        MANYTOMANY, 
        DIAMONDARROW, 
        WIDEARROW, 
        DASHEDARROW
    }
    public enum Conn_Position
    { 
        LEFT,
        TOP,
        RIGHT,
        BOTTOM
    }


    public class DDTConnector
    {
        public int objectId;
        public Conn_Position pos;

        public DDTConnector() { }
        public DDTConnector(int id, Conn_Position p)
        {
            this.objectId = id;
            this.pos = p;
        }
        //p = 0,1,2,3
        public DDTConnector(int id, int p)
        {
            this.objectId = id;
            switch (p)
            { 
                case 1:
                    this.pos = Conn_Position.LEFT;
                    break;
                case 2:
                    this.pos = Conn_Position.TOP;
                    break;
                case 3:
                    this.pos = Conn_Position.RIGHT;
                    break;
                case 4:
                    this.pos = Conn_Position.BOTTOM;
                    break;
                default:
                    this.pos = Conn_Position.RIGHT;
                    break;
            }
        
        }

        public DDTConnector clone()
        {
            return new DDTConnector(this.objectId, this.pos);
        }

    }

    public class DDTRelationTexts
    {
        public string from="";
        public string middle="";
        public string to="";
        
        public DDTRelationTexts() { }

        public DDTRelationTexts(string f, string m, string t)
        {
            if(f!=null)
            from = f;
            if(m!=null)
            middle = m;
            if (t != null)
            to = t;
        }
        public DDTRelationTexts clone()
        {

            return new DDTRelationTexts(from, middle, to);
        
        }
    }

}
