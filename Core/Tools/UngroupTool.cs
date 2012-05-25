using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class UngroupTool : AbstractTool, IMouseListener
    {

        #region Fields
       
        #endregion

        #region Constructor
        public UngroupTool(string name) : base(name)
        { 
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            bool valid = true;
            
            #region Validation of the selection
            
            //make sure we have the correct stuff on the table
            if (Selection.SelectedItems==null || Selection.SelectedItems.Count ==0)
            {
                MessageBox.Show("Nothing is selected, you need to select an existing group.", "Nothing selected.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                valid = false;                
            }
            else if (Selection.SelectedItems.Count != 1)
            {
                MessageBox.Show("Multiple items are selected, select only one group.", "Multiple items", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                valid = false;
            }
            else if (!(Selection.SelectedItems[0] is IGroup))
            {
                MessageBox.Show("The selected item is not a group.", "Not a group.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                valid = false;
            }
            #endregion

            if (valid)
            {
                UngroupCommand cmd = new UngroupCommand(this.Controller, Selection.SelectedItems[0] as IGroup);
                this.Controller.UndoManager.AddUndoCommand(cmd);
                cmd.Redo();
            }
             DeactivateTool();
             return;
        }

        public void MouseDown(MouseEventArgs e)
        {
          
        }

        public void MouseMove(MouseEventArgs e)
        {
           
        }
        public void MouseUp(MouseEventArgs e)
        {
            
        }
        #endregion

      
    }

}
