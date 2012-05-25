using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Drawing;


namespace Netron.NetronLight.Demo
{
    public abstract class ObjectBase 
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    ObjectEvent rename = Rename;
                    if (rename != null)
                        rename(this);
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public delegate void ObjectEvent(ObjectBase obj);
        public event ObjectEvent Rename;
    }

    public abstract class Shape
    {
        public delegate void ShapeEvent(Shape s);
        public event ShapeEvent OnDelete;

        public void RaiseOnDelete()
        {
            ShapeEvent OnDelete = this.OnDelete;
            if (OnDelete != null)
                OnDelete(this);
        }
    }

    public abstract class BlockShape : Shape
    {
        protected Point location;
        [XmlIgnore]
        public abstract string Text { get; set; }
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public abstract BlockShape Clone();
    }

    public class ObjectShape : BlockShape
    {
        ObjectBase actualObject = null;
        [XmlIgnore]
        public override string Text
        {
            get
            {
                return actualObject.Name;
            }
            set
            {
                throw new InvalidOperationException("Can't change the name of an object in a diagram");
            }
        }

        public override BlockShape Clone()
        {
            ObjectShape shape = new ObjectShape();
            shape.actualObject = actualObject;
            shape.location = location;
            return shape;
        }
        
    }

    public class CustomShape : BlockShape
    {
        [XmlType(TypeName = "ShapeSymbol")]
        public enum Symbol { DataStore, EventStore, DataTransform, ControlTransform, Label } // all objectshape types
        string text = "";
        Symbol type;

        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        public Symbol Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public override BlockShape Clone()
        {
            CustomShape shape = new CustomShape();
            shape.text = text;
            shape.type = type;
            shape.location = location;
            return shape;
        }
    }

    public class RelationshipShape : Shape, ICloneable
    {
        [XmlType(TypeName = "RelSymbol")]
        public enum Symbol
        {
            DoubleDouble, SingleDouble, NoneDouble,
            SingleSingle, NoneSingle, NoneNone,
            Generalization, Event
        } // all relationshipshapes types
        Symbol type;
        string startNote;
        string endNote;
        BlockShape startObject;
        BlockShape endObject;
        int startConnector;
        int endConnector;
        string description;

        public RelationshipShape()
        {
            Type = Symbol.Generalization;
            StartNote = null;
            EndNote= null;
            Description= null;
            StartObject= null;
            EndObject= null;
        }

        /// <summary>
        /// Checks if this relationship starts from a given ObjectBase
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <returns>true if the relationship starts at an ObjectShape representing obj</returns>
        public bool StartsAt(ObjectBase obj)
        {
            if (startObject is ObjectShape)
                return (startObject as ObjectShape).ActualObject == obj;
            return false;
        }

        /// <summary>
        /// Checks if this relationship ends at a given ObjectBase
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <returns>true if the relationship ends at an ObjectShape representing obj</returns>
        public bool EndsAt(ObjectBase obj)
        {
            if (endObject is ObjectShape)
                return (endObject as ObjectShape).ActualObject == obj;
            return false;
        }

        public Symbol Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string StartNote
        {
            get
            {
                return startNote;
            }
            set
            {
                startNote = value;
            }
        }

        public string EndNote
        {
            get
            {
                return endNote;
            }
            set
            {
                endNote = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        [XmlIgnore]
        public BlockShape StartObject
        {
            get
            {
                return startObject;
            }
            set
            {
                startObject = value;
            }
        }
        [XmlIgnore]
        public BlockShape EndObject
        {
            get
            {
                return endObject;
            }
            set
            {
                endObject = value;
            }
        }

        public int StartConnector
        {
            get
            {
                return startConnector;
            }
            set
            {
                startConnector = value;
            }
        }

        public int EndConnector
        {
            get
            {
                return endConnector;
            }
            set
            {
                endConnector = value;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
    
     public class Graph
    {
        ArrayList blockShapes = new ArrayList();
        ArrayList relationshipShapes = new ArrayList();

        [XmlElement(Type = typeof(ObjectShape)), XmlElement(Type = typeof(CustomShape))]
        public ArrayList BlockShapes
        {
            get
            {
                return blockShapes;
            }
            set
            {
                blockShapes = value;
            }
        }
        [XmlElement(Type = typeof(RelationshipShape))]
        public ArrayList RelationshipShapes
        {
            get
            {
                return relationshipShapes;
            }
            set
            {
                relationshipShapes = value;
            }
        }
    }

    public class Diagram 
    {
         string Name { get; }
        public enum DiagramType {
            EntityRelationship,
            RelationshipDiagram,
            RelationshipDisplay,
            DFD,
            CFD,
            ClassHierarchy
        } // all types of diagrams

        string name;
        DiagramType type;
        private Graph g;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DiagramType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public Graph G
        {
            get
            {
                return g;
            }
            set
            {
                g = value;
            }
        }

        public Diagram()
        {
            Name = null;
            G = new Graph();
        }

        public bool Add(Shape s)
        {
            if (s is RelationshipShape)
            {
                G.RelationshipShapes.Add(s);
                return true;
            }
            else if (s is BlockShape)
            {
                G.BlockShapes.Add(s);
                return true;
            }
            else
                return false;
        }

        public bool Remove(Shape s)
        {
            if (s is RelationshipShape)
            {
                s.RaiseOnDelete();
                G.RelationshipShapes.Remove(s);
                return true;
            }
            else if (s is BlockShape)
            {
                ArrayList toRemove = new ArrayList(); // needed because we can't remove during iteration
                foreach (RelationshipShape r in G.RelationshipShapes)
                    if(r.StartObject==s||r.EndObject==s)
                        toRemove.Add(r);
                foreach (RelationshipShape r in toRemove)
                    Remove(r);
                s.RaiseOnDelete();
                G.BlockShapes.Remove(s);
                return true;
            }
            else
                return false;
        }

        public bool Contains(ObjectBase s)
        {
            foreach(BlockShape o in G.BlockShapes)
            {
                if(o is ObjectShape)
                    if((o as ObjectShape).ActualObject == s)
                        return true;
            }
            return false;
        }
    }