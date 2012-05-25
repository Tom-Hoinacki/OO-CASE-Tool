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
    public class Operation
    {
        public string operationName;
        public string domain;
        public string range;
        public string purpose;
        public string exceptions;
        public string effects;

        public Operation()
        {
        }
        public Operation(string name, string domain, string range, string purpose, string exceptions, string effects)
        {
            this.operationName = name;
            this.domain = domain;
            this.range = range;
            this.purpose = purpose;
            this.exceptions = exceptions;
            this.effects = effects;
        }
    }

    public class Axiom
    {
        public string rule;
        public Axiom()
        {
            rule = "";
        }
        public Axiom(string rule)
        {
            this.rule = rule;
        }
    }


    public class ADTObject : IDDTElement
    {
        public string name;
        public List<Operation> operations;
        // will need to determine if we want this to just be
        // a list of strings or a single string.
        public List<Axiom> axioms;

        public ADTObject()
            : base()
        {
            //name = ObjectNameGenerator.getNewName();
            operations = new List<Operation>();
            axioms = new List<Axiom>();
        }
        public ADTObject(string name, List<Operation> operations, List<Axiom> axioms)
            : base()
        {
            this.name = name;
            this.operations = operations;
            this.axioms = axioms;
        }
    }
}
