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
using System.Linq;
using System.Text;

namespace DDT
{
    //====================== C - OBJ ===============================================

    public class Attribute   //for concrete objects
    {
        public string name;
        public string description;
        public string domain;
        public bool key;
        // defaul is necessary for serialize.
        public Attribute()
        {
        }
        public Attribute(string name, string description, string domain, bool isKey)
        {
            this.name = name;
            this.description = description;
            this.domain = domain;
            this.key = isKey;
        }
    }



    public class CObject : IDDTElement
    {
        public string name;
        public List<Attribute> attributes;
        public CObject()
            : base()
        {
            //name = ObjectNameGenerator.getNewName();
            attributes = new List<Attribute>();
        }
        public CObject(string name, List<Attribute> attributes)
            : base()
        {
            this.name = name;
            this.attributes = attributes;
        }

    }
}
