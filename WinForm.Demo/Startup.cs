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
using System.Windows.Forms;

namespace Netron.NetronLight.Demo
{

    /// <summary>
    /// The startup class holding the <see cref="STAThread"/>
    /// </summary>
    public class Startup
    {


      /// <summary>
      /// The main entry point for the application.
      /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Using the enablevisualstyles method XP visual styles are applied to your winforms when the application is running on Windows XP.
            Application.EnableVisualStyles();
            //Setting the property to false will make the control use GDI for drawing text
            Application.SetCompatibleTextRenderingDefault(false);


            //test project
            DDT.DDTProject p = new DDT.DDTProject();
            // p.addObject(new DDT.DDTObject(DDT.DDT_Obj_Type.COBJECT, "cObject1"));
          //  p.addObject(new DDT.DDTObject(DDT.DDT_Obj_Type.ADT, "adtObject1"));
           // p.addObject(new DDT.DDTObject(DDT.DDT_Obj_Type.SMOBJECT, "smObject1"));
            DDT.DDTHelper.initialize(p);



            //Launch the messaging loop
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            BugLogging.AddBug(e.Exception.Source, e.Exception.Message);
        }
    }
}
