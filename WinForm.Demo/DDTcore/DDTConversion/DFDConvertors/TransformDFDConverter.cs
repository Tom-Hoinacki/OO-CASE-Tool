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
    /// Static class for now to create an AC from a transform
    /// centered DFD.
    /// </summary>
    public static class TransformDFDConverter
    {
        public static void displayChart(DDTDiagram dfd, int processingStartID, int outputStartID)
        {
            // first lets get the directed graph from the DFD
            DirectedPathNode root = TransactionDFDConverter.getDirectedPath(dfd);
            string processingStart = DDTHelper.manager.project.getDDTObject(processingStartID).ToString();
            string outputStart = DDTHelper.manager.project.getDDTObject(outputStartID).ToString();

            ACNode nullRoot = new ACNode("null root");
            ACNode acRoot = new ACNode("SYSTEM", nullRoot);
            ACNode input = new ACNode("INPUT", acRoot);
            ACNode processing = new ACNode("PROCESSING", acRoot);
            ACNode output = new ACNode("OUTPUT", acRoot);

            acRoot.addChild(input);
            acRoot.addChild(processing);
            acRoot.addChild(output);

            DirectedPathNode current = root;
            // build the input tree.
            while (current.name != processingStart)
            {
                ACNode newNode = new ACNode(current.name, input);
                input.addChild(newNode);
                current = current.next[0];
            }
            // build the processing tree.
            while (current.name != outputStart)
            {
                ACNode newNode = new ACNode(current.name, processing);
                processing.addChild(newNode);
                current = current.next[0];
            }
            // build output tree.
            while (current != null)
            {
                ACNode newNode = new ACNode(current.name, output);
                output.addChild(newNode);
                current = current.next[0];
            }




            // actually create the architecture chart.
            TreeData.TreeDataTableDataTable dtTree = new TreeData.TreeDataTableDataTable();
            acRoot.getTree(dtTree);


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

    }
}
