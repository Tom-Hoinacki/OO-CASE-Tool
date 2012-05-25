using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using DDT;
using System.Windows.Forms;
namespace DDT
{
    public class TestProj
    {
        public static DDTProject createDDTProject()
        {
            List<DDT_Obj_Property> properties = new List<DDT_Obj_Property>();
            properties.Add(new DDT_Obj_Property("p", "d", "v"));
            properties.Add(new DDT_Obj_Property("p1", "d1", "v1"));
            List<DDT_Obj_Event> events = new List<DDT_Obj_Event>();
            events.Add(new DDT_Obj_Event("s","s"));
            events.Add(new DDT_Obj_Event("s1", "s1"));

            DDTObject o1 = new DDTObject(DDT_Obj_Type.ADT, "obj1",properties,events);
            DDTObject o2 = new DDTObject(DDT_Obj_Type.SMOBJECT, "obj2");
            DDTObject o3 = new DDTObject(DDT_Obj_Type.DATASTORE, "obj3");
            DDTObject o4 = new DDTObject(DDT_Obj_Type.TERMINATOR, "obj4");

            DDTConnector from1 = new DDTConnector(1, 3);
            DDTConnector to1 = new DDTConnector(2, 1);
            DDTConnector from2 = new DDTConnector(3, 3);
            DDTConnector to2 = new DDTConnector(2, 3);
            DDTConnector from3 = new DDTConnector(1, 4);
            DDTConnector to3 = new DDTConnector(4, 1);

           


            DDTRelationTexts text1 = new DDTRelationTexts("1", "s", "s");


            DDTRelation r1 = new DDTRelation(DDT_Rel_Type.ONETOMANY, from1, to1, text1);
            DDTRelation r2 = new DDTRelation(DDT_Rel_Type.WIDEARROW, from2, to2, null);
            DDTRelation r3 = new DDTRelation(DDT_Rel_Type.SINGLEARROW, from3, to3, null);



            List<DDTObjectReference> obl = new List<DDTObjectReference>();
            obl.Add(new DDTObjectReference(1, new Point(100,100)));
            obl.Add(new DDTObjectReference(2, new Point(200, 300)));
            obl.Add(new DDTObjectReference(3, new Point(300, 200)));
            obl.Add(new DDTObjectReference(4, new Point(400, 400)));

            List<int> rel = new List<int>();
            rel.Add(5); rel.Add(6); rel.Add(7);

            DDTDiagram diagram1 = new DDTDiagram("dia1", DDT_Diagram_Type.ERD, obl, rel);

            List<DDTDiagram> dia=new List<DDTDiagram>();
            dia.Add(diagram1);
            List<DDTObject> obj = new List<DDTObject>();
            obj.Add(o1); obj.Add(o2); obj.Add(o3); obj.Add(o4);
            List<DDTRelation> re = new List<DDTRelation>();
            re.Add(r1); re.Add(r2); re.Add(r3);


            DDTProject proj = new DDTProject("pro1", dia,obj ,re);

            return proj;

        }



    }
}
