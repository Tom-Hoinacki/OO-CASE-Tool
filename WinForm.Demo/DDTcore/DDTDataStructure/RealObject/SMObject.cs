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
    //====================== SM - OBJ ===============================================

    public class SMEvent
    {
        // we don't care about the actual object being stored, or its ID the name should
        // be enough.  because the name should be unique.
        public List<string> dataEvents;
        public List<string> operations;
        public string nextState;
        public string name;

        public SMEvent()
        {
            dataEvents = new List<string>();
            operations = new List<string>();
            nextState = "";
            name = "";
        }

        public SMEvent(List<string> dataEvents, List<string> operations, string nextState, string name)
        {
            this.dataEvents = dataEvents;
            this.operations = operations;
            this.nextState = nextState;
            this.name = name;
        }
    }


    public class SMObject : IDDTElement
    {
        public string name;
        // I don't think we care about anything besides the name.
        // so this is the list of objects associated with the SMObject
        // TODO will have to remove referenced objects!
        public List<string> dataObjects;

        // defined operations for the SM Object.
        public List<string> operations;

        // events associated with the SMObject.
        public List<SMEvent> events;

        public SMObject()
            : base()
        {
            dataObjects = new List<string>();
            operations = new List<string>();
            events = new List<SMEvent>();
            //name = ObjectNameGenerator.getNewName();
        }

        public SMObject(string name, List<string> objects, List<string> operations, List<SMEvent> events)
            : base()
        {
            this.name = name;
            this.dataObjects = objects;
            this.operations = operations;
            this.events = events;
        }

    }

}
