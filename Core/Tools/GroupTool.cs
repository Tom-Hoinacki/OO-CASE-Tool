using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class GroupTool : AbstractTool, IMouseListener
    {

        #region Fields
     
        #endregion

        #region Constructor
        public GroupTool(string name)
            : base(name)
        {
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            bool valid = true;
            //make sure we have the correct stuff on the table
            if (Selection.SelectedItems == null || Selection.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nothing is selected, you need to select at least two items to create a group.", "Nothing selected.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                valid = false;
            }
            else if (Selection.SelectedItems.Count <= 1)
            {
                MessageBox.Show("You need at least two items to create a group.", "Multiple items.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                valid = false;
            }
            if (valid)
            {
                Bundle bundle = new Bundle(Selection.SelectedItems);

                GroupCommand cmd = new GroupCommand(this.Controller, bundle);

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
