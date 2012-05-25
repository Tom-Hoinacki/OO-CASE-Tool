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
using TreeGenerator;

namespace DDT
{
    class ACNode
    {
        public static int ID_SEED = 0;
        public string id; // the id of root must be ""
        public string name;
        public ACNode parent;
        public List<ACNode> children;

        public ACNode(string name, ACNode parent)
        {
            ID_SEED++;
            this.id = ID_SEED.ToString();
            this.name = name;
            this.parent = parent;
            this.children = new List<ACNode>();
        }

        // to create a null root. Root is unused as part of the processing.
        public ACNode(string name)
        {
            this.id = "";
            this.name = name;
            this.parent = null;
            this.children = new List<ACNode>();
        }

        public void addChild(ACNode node)
        {
            children.Add(node);
        }

        public override string ToString()
        {
            return "id =" + id + ", name =" + name;
        }

        /// <summary>
        /// recursive algorithm to generate a Tree.
        /// </summary>
        /// <param name="?">data structure getting built incrementally.</param>
        public void getTree(TreeData.TreeDataTableDataTable treeSoFar)
        {
            treeSoFar.AddTreeDataTableRow(id, parent.id, name, "");
            foreach (ACNode n in children)
            {
                n.getTree(treeSoFar);
            }
        }


        
    }
}
