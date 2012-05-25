using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
namespace Netron.NetronLight.Win
{
    [
    ToolboxBitmap(typeof(DiagramControl), "DiagramControl.bmp"),
    ToolboxItem(true),
    Description("Generic diagramming control for .Net"),
    Designer(typeof(Netron.NetronLight.Win.DiagramControlDesigner)),
    DefaultProperty("Name"),
    DefaultEvent("OnMouseDown")]
    public class DiagramControl : DiagramControlBase
    {

        #region Events
        public event EventHandler<SelectionEventArgs> OnShowSelectionProperties;
        public event EventHandler<EntityEventArgs> OnEntityAdded;
        public event EventHandler<EntityEventArgs> OnEntityRemoved;
        #endregion

        #region Fields
        private ContextMenu menu;
        public int diagramID;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <value>The selected items.</value>
        public CollectionBase<IDiagramEntity> SelectedItems
        {
            get {
                return Selection.SelectedItems;
            }
        }
 


        #endregion

       
        #region Constructor

        public DiagramControl() : base()
        {
            //double-buffering
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //init the MVC
            Controller = new Controller(this);//the controller will create the model
            Controller.OnHistoryChange += new EventHandler<HistoryChangeEventArgs>(mController_OnHistoryChange);
            Controller.OnShowSelectionProperties += new EventHandler<SelectionEventArgs>(Controller_OnShowSelectionProperties);
            Controller.OnEntityAdded += new EventHandler<EntityEventArgs>(Controller_OnEntityAdded);
            Controller.OnEntityRemoved += new EventHandler<EntityEventArgs>(Controller_OnEntityRemoved);
            View = Controller.View;
            //the diagram document is the total serializable package
            Document = new Document(View.Model);

            TextEditor.Init(this);

            //menu
            menu = new ContextMenu();            

            View.OnCursorChange += new EventHandler<CursorEventArgs>(mView_OnCursorChange);

            this.AllowDrop = true;
        }


        public IController controller
        {
            get { return this.Controller; }

        }

        void Controller_OnEntityRemoved(object sender, EntityEventArgs e)
        {
            RaiseOnEntityRemoved(e);
        }

        void Controller_OnEntityAdded(object sender, EntityEventArgs e)
        {
            RaiseOnEntityAdded(e);
        }

        void Controller_OnShowSelectionProperties(object sender, SelectionEventArgs e)
        {
            RaiseOnShowSelectionProperties(e);
        }



        #endregion


        #region Methods

        

        public void AddShape(IShape shape)
        {
 
            this.Controller.Model.AddShape(shape);            
        }
       
        public void AddConnection(IConnection conn)
        {

            this.Controller.Model.AddConnection(conn);
        }
         
        void mController_OnHistoryChange(object sender, HistoryChangeEventArgs e)
        {
            RaiseOnHistoryChange(e);
        }
        void mView_OnCursorChange(object sender, CursorEventArgs e)
        {
           this.Cursor = e.Cursor;
        }
        private void BuildMenu()
        {
            menu.MenuItems.Clear();

            MenuItem mnuDelete = new MenuItem("Delete", new EventHandler(OnDelete));
            menu.MenuItems.Add(mnuDelete);

            MenuItem mnuProps = new MenuItem("Properties", new EventHandler(OnProperties));
            menu.MenuItems.Add(mnuProps);

            MenuItem mnuDash = new MenuItem("-");
            menu.MenuItems.Add(mnuDash);

            if (EnableAddConnection)
            {
                MenuItem mnuNewConnection = new MenuItem("Add connection", new EventHandler(OnNewConnection));
                menu.MenuItems.Add(mnuNewConnection);
            }

            MenuItem mnuShapes = new MenuItem("Shapes");
            menu.MenuItems.Add(mnuShapes);

            MenuItem mnuRecShape = new MenuItem("Rectangular", new EventHandler(OnRecShape));
            mnuShapes.MenuItems.Add(mnuRecShape);
            /*
            MenuItem mnuOvalShape = new MenuItem("Oval", new EventHandler(OnOvalShape));
            mnuShapes.MenuItems.Add(mnuOvalShape);

            MenuItem mnuTLShape = new MenuItem("Text label", new EventHandler(OnTextLabelShape));
            mnuShapes.MenuItems.Add(mnuTLShape);

            MenuItem mnuClassShape = new MenuItem("Class bundle", new EventHandler(OnClassShape));
            mnuShapes.MenuItems.Add(mnuClassShape);

            */

        }
        private void OnDelete(object sender, EventArgs e)
        { }

        private void OnProperties(object sender, EventArgs e)
        {

        }
        private void OnRecShape(object sender, EventArgs e)
        {
        }
        private void OnNewConnection(object sender, EventArgs e)
        {

        }

        protected virtual void RaiseOnShowSelectionProperties(SelectionEventArgs e)
        {
            EventHandler<SelectionEventArgs> handler = OnShowSelectionProperties;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RaiseOnEntityAdded(EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RaiseOnEntityRemoved(EntityEventArgs e)
        {
            EventHandler<EntityEventArgs> handler = OnEntityRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        #endregion

        

        
    }
}
