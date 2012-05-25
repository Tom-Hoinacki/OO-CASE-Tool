
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
using System.Drawing;
using System.Windows.Forms;

namespace DDT
{
    /// <summary>
    /// Static class for now to create an AC from a transaction
    /// centered DFD.
    /// </summary>
    public static class TransactionDFDConverter
    {
        public const int DISPATCHER_INDEX = 1;
        public const int MAIN_PATH = 0;

        public static void displayChart(DDTDiagram dfd)
        {
            DirectedPathNode root = getDirectedPath(dfd);


            ACNode acRoot = getArchitectureChart(root);
            
            TreeData.TreeDataTableDataTable dtTree = new TreeData.TreeDataTableDataTable();
            acRoot.getTree(dtTree);
            /*dtTree.AddTreeDataTableRow("12", "", "System", "");
            dtTree.AddTreeDataTableRow("1", "12", "Input", "");
            dtTree.AddTreeDataTableRow("2", "12", "Process", "");
            dtTree.AddTreeDataTableRow("3", "12", "Output", "");
            dtTree.AddTreeDataTableRow("4", "1", "3000", "");
            dtTree.AddTreeDataTableRow("5", "1", "3001", "");
            dtTree.AddTreeDataTableRow("6", "2", "3000", "");
            dtTree.AddTreeDataTableRow("7", "4", "4000", "");
            dtTree.AddTreeDataTableRow("8", "4", "4001", "");
            */


            TreeBuilder t = new TreeBuilder(dtTree);
            //Now - Generate the tree itself
            Image i = Image.FromStream(
                t.GenerateTree(acRoot.id,
                System.Drawing.Imaging.ImageFormat.Bmp));
            i.Save("C://test.bmp");

            //ExecuteCommand("C://test.bmp", 100);
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.Image = i;

            Form newForm = new Form();
            newForm.Controls.Add(pb);
            newForm.AutoSize = true;
            newForm.BackColor = Color.White;
            newForm.Show();



        }

        #region functions to help getting a directed graph from an architecture chart.
        public static DirectedPathNode getDirectedPath(DDTDiagram dfd)
        {
            DirectedPathNode root = null;
            DirectedPathNode left = null;
            DirectedPathNode right = null;


            // method to produce the list is to do so by brute force, iterate 
            // over the existing relations until all are accounted for or 1000
            // tries have been made;
            int timeout = 0;
            List<DDTRelation> totalRelations = new List<DDTRelation>();
            List<DirectedPathNode> nodes = new List<DirectedPathNode>();

            // Step 1. retrieve all of the relations
            foreach (int i in dfd.RelIDList)
            {
                totalRelations.Add(DDTHelper.manager.project.getDDTRelation(i));
            }

            // Step 2. loop until the relations are accounted for or a timeout.

            // create an arbitrary element in the total tree.
            DDTRelation first = totalRelations[0];
            totalRelations.RemoveAt(0);
            left = new DirectedPathNode(DDTHelper.manager.project.getDDTObject(first.from.objectId).name);
            right = new DirectedPathNode(DDTHelper.manager.project.getDDTObject(first.to.objectId).name);
            left.addNode(right);
            nodes.Add(left);
            nodes.Add(right);

            // now add relations as we can to build the tree. 
            int index = 0;
            
                bool canUse = true; // jsut for logic.
            while ((totalRelations.Count > 0) && (timeout < 1000))
            {
                if(!canUse)
                {
                    index++;
                    if (index >= totalRelations.Count)
                    {
                        index = 0;
                    }
                }
                canUse = false;
                // always remove from top of list
                DDTRelation next = totalRelations[0];

                for(int i =0;i<nodes.Count;i++)
                {
                    if (canUse)
                    {
                        continue;
                    }
                    DirectedPathNode current = nodes[i];
                    // case where the currently selected node in in the relations in the from position.
                    if (current.name == DDTHelper.manager.project.getDDTObject(next.from.objectId).name)
                    {
                        right = new DirectedPathNode(DDTHelper.manager.project.getDDTObject(next.to.objectId).name);
                        if (nodes.Contains(right))
                        {
                            // if the right already exists we just need to add the relation.
                            right = nodes.ElementAt(nodes.IndexOf(right));
                            current.addNode(right);
                        }
                        else
                        {
                            // we actually need to create the node.
                            current.addNode(right);
                            nodes.Add(right);
                        }
                        totalRelations.RemoveAt(index); // remove the handled relation.
                        canUse = true;
                    }
                    // case where the currently selected node is in the to position.
                    else if (current.name == DDTHelper.manager.project.getDDTObject(next.to.objectId).name)
                    {
                        left = new DirectedPathNode(DDTHelper.manager.project.getDDTObject(next.from.objectId).name);
                        if (nodes.Contains(left))
                        {
                            // if the left already exists we just need to add the relation.
                            left = nodes.ElementAt(nodes.IndexOf(left));
                            left.addNode(current);
                        }
                        else
                        {
                            // we actually need to create the node.
                            current.addPreviousReference(left);
                            nodes.Add(left);
                        }

                        totalRelations.RemoveAt(index); // remove the handled relation.
                        canUse = true;
                    }
                    

                }

            }

            // Step 3: find the root.
            root = nodes[0];
            while (root.previous[MAIN_PATH] != null)
            {
                root = root.previous[MAIN_PATH];
            }



            return root;
        }

        #endregion



        #region functions to help create the architecture chart from a well formed Directed Path.

        private static ACNode getArchitectureChart(DirectedPathNode root)
        {
            // Algorithm to generate architecture chart.

            // Start with the root node.
            ACNode nullRoot = new ACNode("null root");
            ACNode acRoot = new ACNode("SYSTEM", nullRoot);
            ACNode inputRoot = null;
            ACNode outputRoot = null;
            DirectedPathNode current = null;

            // determine now many input nodes there are.
            int inputNodes = getInputNodes(root);

            // build input tree.
            current = root;
            buildInputTree(current, acRoot, inputRoot, inputNodes);

            current = getDispatcher(root);
            acRoot.addChild(new ACNode(current.name, acRoot));

            // now we must build the dispatch tree.
            buildDispatchTree(current, acRoot);

            // now we need to build the output tree.
            int outputNodes = getOutputNodes(root);

            // build input tree.
            current = root;
            buildOutputTree(current, acRoot, outputRoot, outputNodes);

            return acRoot;
        }
        private static DirectedPathNode getDispatcher(DirectedPathNode root)
        {
            bool dispatcherFound = false;
            DirectedPathNode dispatcher = root;

            while (!dispatcherFound)
            {
                if (dispatcher.divergentPaths() > 1)
                {
                    dispatcherFound = true;
                }
                else
                {
                    dispatcher = dispatcher.next[MAIN_PATH];
                }
            }
            return dispatcher;

        }

        private static int getOutputNodes(DirectedPathNode root)
        {
            bool foundConverger = false;
            DirectedPathNode current = root;
            int numberOfOutput = 0;
            // find converging nodes.
            while (!foundConverger)
            {
                if (current.convergentPaths() > 1)
                {
                    foundConverger = true;
                    numberOfOutput++;
                }
                else
                {
                    current = current.next[MAIN_PATH];
                }
            }
            // determine number of output nodes.
            while (current.next[MAIN_PATH] != null)
            {
                numberOfOutput++;
                current = current.next[MAIN_PATH];
            }
            return numberOfOutput;
        }

        private static void buildInputTree(DirectedPathNode current, ACNode acRoot, ACNode inputRoot, int inputNodes)
        {
            if (inputNodes > 1)
            {
                inputRoot = new ACNode("INPUT", acRoot);
                acRoot.addChild(inputRoot);

                int inputIndex = 0;
                while (inputIndex < inputNodes)
                {
                    inputRoot.addChild(new ACNode(current.name, inputRoot));
                    current = current.next[MAIN_PATH];
                    inputIndex++;
                }
            }
            else // just one input node.
            {
                inputRoot = new ACNode(current.name, acRoot);
                acRoot.addChild(inputRoot);
            }
        }

        private static int getInputNodes(DirectedPathNode root)
        {
            bool foundDispatch = false;
            DirectedPathNode current = root;
            int numberOfInput = 0;
            while (!foundDispatch)
            {
                if (current.divergentPaths() > 1)
                {
                    foundDispatch = true;
                }
                else
                {
                    numberOfInput++;
                    current = current.next[MAIN_PATH];
                }
            }
            return numberOfInput;
        }

        /// <summary>
        /// Can only handle linear nodes on the dispatch tree.
        /// Can handle any number of branches and any length of strings
        /// though.
        /// </summary>
        /// <param name="d">d is the dispatcher node from which we buld.</param>
        private static void buildDispatchTree(DirectedPathNode d, ACNode root)
        {
            DirectedPathNode current = d.next[MAIN_PATH]; // start on the first element off dispatcher.
            int path = MAIN_PATH;
            ACNode dispatcher = root.children[DISPATCHER_INDEX];
            ACNode currentDepth = dispatcher;
            while (path < d.divergentPaths())
            {
                // add path node.
                current = d.next[path]; 
                currentDepth = dispatcher;
                currentDepth.addChild(new ACNode(current.name, currentDepth));
                currentDepth = currentDepth.children[path];
                current = current.next[MAIN_PATH];


                // we are going to go along the path until we reach
                // the convergence point.
                while (current.convergentPaths() == 1)
                {

                    currentDepth.addChild(new ACNode(current.name, currentDepth));
                    currentDepth = currentDepth.children[MAIN_PATH]; // want to select the path we just added.
                    current = current.next[MAIN_PATH];  // needs to be last so the while doesn't give us a problem
                }
                // lets do the next node.
                path++;
            }
        }

        private static void buildOutputTree(DirectedPathNode root, ACNode acRoot, ACNode outputRoot, int outputNodes)
        {
            bool foundConverger = false;
            DirectedPathNode current = root;
            if (outputNodes > 1)
            {
                outputRoot = new ACNode("OUTPUT", acRoot);
                acRoot.addChild(outputRoot);

                while (!foundConverger)
                {
                    if (current.convergentPaths() > 1)
                    {
                        foundConverger = true;
                    }
                    else
                    {
                        current = current.next[MAIN_PATH];
                    }
                }
                // current = converger.
                int index = 0;
                while (index < outputNodes)
                {
                    outputRoot.addChild(new ACNode(current.name, outputRoot));
                    current = current.next[MAIN_PATH];
                    index++;
                }
            }
            else // just one input node.
            {
                outputRoot = new ACNode(current.name, acRoot);
                acRoot.addChild(outputRoot);
            }
        }
        #endregion

    }
}
