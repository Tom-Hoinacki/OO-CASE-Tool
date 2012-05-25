using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class HitTool : AbstractTool, IMouseListener
    {

        #region Fields
       

     

        #endregion

        #region Constructor
        public HitTool(string name)
            : base(name)
        {
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            

        }

        public void MouseDown(MouseEventArgs e)
        {
            
            if(e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            if(e.Button == MouseButtons.Left  && Enabled && !IsSuspended)
            {

                
                 if (e.Clicks == 1)
                { 
                    TextEditor.Hide();
                    Selection.CollectEntitiesAt(e.Location);
                   
                    if(Selection.SelectedItems.Count > 0)
                    {
                        IMouseListener listener = Selection.SelectedItems[0].GetService(typeof(IMouseListener)) as IMouseListener;
                        if(listener != null)
                        {
                            listener.MouseDown(e);
                        }
                    }
                   
                    return;
                }else if (e.Clicks == 2)
                {
                    TextEditor.Hide();
                    Selection.CollectEntitiesAt(e.Location);

                    this.Controller.RaiseOnShowContextMenu2(e);

                    return;
                }
                
                return;
            }
            else if (e.Button == MouseButtons.Right && Enabled && !IsSuspended)
            {

                if (e.Clicks == 1)
                {
                     
                    TextEditor.Hide();
                    Selection.CollectEntitiesAt(e.Location);

                    //MenuItem[] additionalItems = null;
                   //1. //this.Controller.RaiseOnShowContextMenu(new EntityMenuEventArgs(null, e, ref additionalItems));
                    this.Controller.RaiseOnShowContextMenu(e);
                      
                    return;
                }
                    //on double right click, remove the object
                else if (e.Clicks == 2)
                {

                    TextEditor.Hide();
                    Selection.CollectEntitiesAt(e.Location);

                    IDDTDiagramEntity IDDT = (IDDTDiagramEntity)Selection.SelectedItems[0];

                    if (MessageBox.Show("Remove "+IDDT.getText()+" from the diagram?", "Confirm To Remove", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                    {

                        this.Controller.Model.Remove(IDDT);
                        Selection.Clear();
                        this.Controller.View.ShowTracker();
                    }

                    return;
                }
                return;
            }


            return;
            
        }

        public void MouseMove(MouseEventArgs e)
        {
      
        }
      
        public void MouseUp(MouseEventArgs e)
        {
            if(IsActive)
            {
                DeactivateTool();
            }
        }
        #endregion
    }

}
