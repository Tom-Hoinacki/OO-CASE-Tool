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
    // This data structure will aid in created the directed path
    // represented in the DFD.
    public class DirectedPathNode
    {
        public static int MAX_DEPTH = 8;
        public DirectedPathNode[] next;
        public int nextIndex;
        public DirectedPathNode[] previous;
        public int previousIndex;
        public string name;

        public DirectedPathNode(string name)
        {
            next = new DirectedPathNode[MAX_DEPTH];
            previous = new DirectedPathNode[MAX_DEPTH];
            nextIndex = 0;
            previousIndex = 0;
            this.name = name;
        }


        public void addNode(DirectedPathNode newNode)
        {
            next[nextIndex++] = newNode;
            newNode.previous[newNode.previousIndex++] = this;
        }
        public void addPreviousReference(DirectedPathNode node)
        {
            previous[previousIndex] = node;
            previousIndex++;
        }
        public int divergentPaths()
        {
            return nextIndex;
        }
        public int convergentPaths()
        {
            return previousIndex;
        }
        public override bool Equals(Object o)
        {
            DirectedPathNode local = (DirectedPathNode)o;
            if (local.name == this.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
