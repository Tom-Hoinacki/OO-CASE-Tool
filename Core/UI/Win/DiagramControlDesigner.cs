using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;
using System.Reflection;

namespace Netron.NetronLight.Win
{
	/// <summary>
	/// Control designer of the graph-control
	/// </summary>
    internal class DiagramControlDesigner : ControlDesigner
	{
		

		#region Properties

        /// <summary>
        /// the AnotherOne field
        /// </summary>
        private int mAnotherOne;
        /// <summary>
        /// Gets or sets the AnotherOne
        /// </summary>
        [Browsable(true)]
        public int AnotherOne
        {
            get { return mAnotherOne; }
            set { mAnotherOne = value; }
        }
	
		/// <summary>
		/// Gets the verbs of the control
		/// </summary>
		public override System.ComponentModel.Design.DesignerVerbCollection Verbs
		{
			get
			{		
				DesignerVerbCollection col=new DesignerVerbCollection();
				col.Add(new DesignerVerb("About",new EventHandler(About)));
				col.Add(new DesignerVerb("Help",new EventHandler(NetronSite)));
				return col;
			}
		}
		#endregion

		#region Constructor
		public DiagramControlDesigner()
		{
            //Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Netron.NetronLight.UI.AboutSplash.jpg");
					
            //bmp= Bitmap.FromStream(stream) as Bitmap;
            //stream.Close();
            //stream=null;

		}
		#endregion

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create action list collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Add custom action list
                actionLists.Add(new DiagramControlDesignerActionList(this.Component));

                // Return to the designer action service
                return actionLists;
            }
        }

		public override void Initialize(System.ComponentModel.IComponent component)
		{
			base.Initialize (component);
			(component as Control).AllowDrop = false;
			(component as DiagramControl).BackColor = Color.White;
			//(component as GraphControl).EnableContextMenu = true;
		}
		

		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			base.OnPaintAdornments (pe);
			System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
			pe.Graphics.DrawString("Netron Light Version " + ass.GetName().Version.ToString(),ArtPallet.DefaultFont,Brushes.DimGray,new PointF(10,10));

			//pe.Graphics.DrawImage(bmp,10,100,530,228);

			pe.Graphics.DrawString("The graph library comes with some default shapes, if you want additional shapes you need to import them via the app.config. See the tutorials on the Netron site for more information on this." + Environment.NewLine + "The properties of the diagram and diagram entities are accessible via the PropertyGrid, you need to connect the graph control to the PropertyGrid via the OnShowProperties event.",ArtPallet.DefaultFont, Brushes.DimGray,new Rectangle(10,400, 500,300));
			
		}


		

		
		private void About(object sender, EventArgs e)
		{
			//Form frm = new Netron.GraphLib.AboutForm(true);
			//frm.ShowDialog();
		}

		private void NetronSite(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://netron.sf.net");
		}
	
	}
}
