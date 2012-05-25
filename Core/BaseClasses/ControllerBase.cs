using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
namespace Netron.NetronLight
{
    public abstract class ControllerBase : IUndoSupport, IController
    {
        #region Events
        public event EventHandler<ToolEventArgs> OnToolDeactivate;
        public event EventHandler<ToolEventArgs> OnToolActivate;
        public event EventHandler<HistoryChangeEventArgs> OnHistoryChange;
        public event EventHandler<SelectionEventArgs> OnShowSelectionProperties;
        public event EventHandler<EntityEventArgs> OnEntityAdded;
        public event EventHandler<EntityEventArgs> OnEntityRemoved;
        public event EventHandler<MouseEventArgs> OnMouseDown;
        //5./public event EventHandler<EntityMenuEventArgs> OnShowContextMenu;
        public event EventHandler<MouseEventArgs> OnShowContextMenu;
        public event EventHandler<MouseEventArgs> OnShowContextMenu2;
        public event EventHandler<EntityMenuEventArgs> OnShowObjectMenu;
        #endregion

        #region Fields

        private bool eventsEnabled = true;
        private bool controllerEnabled = true;

        private Model mModel;
        private UndoManager mUndoManager;
        private IView mView;
        private CollectionBase<IMouseListener> mouseListeners;
        private CollectionBase<IKeyboardListener> keyboardListeners;
        private CollectionBase<IDragDropListener> dragdropListeners;
        private IDiagramControl parentControl;

       
        private CollectionBase<ITool> registeredTools;
        
        #endregion

        #region Properties
        public bool Enabled
        {
            get
            {
                return controllerEnabled;
            }
            set
            {
                controllerEnabled = value;
            }
        }

         public IDiagramControl ParentControl
        {
            get { return parentControl; }
            internal set { parentControl = value; }
        }
        public CollectionBase<ITool> Tools
        {
            get { return registeredTools; }
        }
        


        public  UndoManager UndoManager
        {
            get
            {
                return mUndoManager;
            }

        }

        public Model Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }

        public IView View
        {
            get
            {
                return mView;
            }
            set
            {
                mView = value;
            }
        }
        #endregion

        #region Constructor
        protected ControllerBase(IDiagramControl surface)
        {
            //doesn't work if you supply a null reference
            if(surface==null)
                throw new NullReferenceException("The diagram control assigned to the controller cannot be 'null'");

            mModel = new Model();
            mModel.OnEntityAdded += new EventHandler<EntityEventArgs>(mModel_OnEntityAdded);
            mModel.OnEntityRemoved += new EventHandler<EntityEventArgs>(mModel_OnEntityRemoved);
            //create the undo/redo manager
            mUndoManager = new UndoManager(15);
            mUndoManager.OnHistoryChange += new EventHandler(mUndoManager_OnHistoryChange);

            #region Instantiation of listeners
            mouseListeners = new CollectionBase<IMouseListener>();
            keyboardListeners = new CollectionBase<IKeyboardListener>();
            dragdropListeners = new CollectionBase<IDragDropListener>();
            #endregion
            //keep a reference to the parent control
            parentControl = surface;

            ListenTo(parentControl);
            
           

            //Make sure the static selection class knows about the model
            Selection.Controller = this;
            //Initialize the colorscheme
            ArtPallet.Init();
 
            ConnectionPen.Init();

           #region Tools: the registration order matters!

            registeredTools = new CollectionBase<ITool>();

            //customized
            DDTConnectionTool DDTConnectionTool = new DDTConnectionTool("DDTConnection Tool");
            DDTConnectionTool.Controller = this;
            this.AddTool(DDTConnectionTool);

            DDTConnectionTool NormalConnectionTool = new NormalConnectionTool("NormalConnection Tool");
            NormalConnectionTool.Controller = this;
            this.AddTool(NormalConnectionTool);

            DDTConnectionTool SingleArrowConnectionTool = new SingleArrowConnectionTool("SingleArrowConnection Tool");
            SingleArrowConnectionTool.Controller = this;
            this.AddTool(SingleArrowConnectionTool);

            DDTConnectionTool DoubleArrowConnectionTool = new DoubleArrowConnectionTool("DoubleArrowConnection Tool");
            DoubleArrowConnectionTool.Controller = this;
            this.AddTool(DoubleArrowConnectionTool);


            DDTConnectionTool WideArrowConnectionTool = new WideArrowConnectionTool("WideArrowConnection Tool");
            WideArrowConnectionTool.Controller = this;
            this.AddTool(WideArrowConnectionTool);

            DDTConnectionTool DiamondArrowConnectionTool = new DiamondArrowConnectionTool("DiamondArrowConnection Tool");
            DiamondArrowConnectionTool.Controller = this;
            this.AddTool(DiamondArrowConnectionTool);

            DDTConnectionTool OneToOneConnectionTool = new OneToOneConnectionTool("OneToOneConnection Tool");
            OneToOneConnectionTool.Controller = this;
            this.AddTool(OneToOneConnectionTool);

            DDTConnectionTool OneToManyConnectionTool = new OneToManyConnectionTool("OneToManyConnection Tool");
            OneToManyConnectionTool.Controller = this;
            this.AddTool(OneToManyConnectionTool);

            DDTConnectionTool ManyToManyConnectionTool = new ManyToManyConnectionTool("ManyToManyConnection Tool");
            ManyToManyConnectionTool.Controller = this;
            this.AddTool(ManyToManyConnectionTool);

            DDTConnectionTool DashedArrowConnectionTool = new DashedArrowConnectionTool("DashedArrowConnection Tool");
            DashedArrowConnectionTool.Controller = this;
            this.AddTool(DashedArrowConnectionTool);

            /*
             * TBC
             */



            TransformTool transformer = new TransformTool("Transform Tool");
            transformer.Controller = this;
            this.AddTool(transformer);

            HitTool hitter = new HitTool("Hit Tool");
            hitter.Controller = this;
            this.AddTool(hitter);

            MoveTool mover = new MoveTool("Move Tool");
            mover.Controller = this;
            this.AddTool(mover);

            RectangleTool recter = new RectangleTool("Rectangle Tool");
            recter.Controller = this;
            this.AddTool(recter);

            EllipseTool ellipser = new EllipseTool("Ellipse Tool");
            ellipser.Controller = this;
            this.AddTool(ellipser);

            SelectionTool selecter = new SelectionTool("Selection Tool");
            selecter.Controller = this;
            this.AddTool(selecter);

            DragDropTool dragdropper = new DragDropTool("DragDrop Tool");
            dragdropper.Controller = this;
            this.AddTool(dragdropper);

            ConnectionTool connecter = new ConnectionTool("Connection Tool");
            connecter.Controller = this;
            this.AddTool(connecter);

            ConnectorMoverTool conmover = new ConnectorMoverTool("Connector Mover Tool");
            conmover.Controller = this;
            this.AddTool(conmover);

            GroupTool grouper = new GroupTool("Group Tool");
            grouper.Controller = this;
            this.AddTool(grouper);

            UngroupTool ungrouper = new UngroupTool("Ungroup Tool");
            ungrouper.Controller = this;
            this.AddTool(ungrouper);

            SendToBackTool sendback = new SendToBackTool("SendToBack Tool");
            sendback.Controller = this;
            this.AddTool(sendback);

            SendBackwardsTool sendbackwards = new SendBackwardsTool("SendBackwards Tool");
            sendbackwards.Controller = this;
            this.AddTool(sendbackwards);

            SendForwardsTool sendforwards = new SendForwardsTool("SendForwards Tool");
            sendforwards.Controller = this;
            this.AddTool(sendforwards);

            SendToFrontTool sendfront = new SendToFrontTool("SendToFront Tool");
            sendfront.Controller = this;
            this.AddTool(sendfront);

            TextTool texttool = new TextTool("Text Tool");
            texttool.Controller = this;
            this.AddTool(texttool);

            HoverTool hoverer = new HoverTool("Hover Tool");
            hoverer.Controller = this;
            this.AddTool(hoverer);



            //this.AddTool(new ContextTool("Context Tool"));
            #endregion
            
        }

        void mModel_OnEntityRemoved(object sender, EntityEventArgs e)
        {
            RaiseOnEntityRemoved(e);
        }

        void mModel_OnEntityAdded(object sender, EntityEventArgs e)
        {
            RaiseOnEntityAdded(e);
        }

        void mUndoManager_OnHistoryChange(object sender, EventArgs e)
        {
            RaiseOnHistoryChange();
        }

        private void RaiseOnHistoryChange()
        {
            EventHandler<HistoryChangeEventArgs> handler = OnHistoryChange;
            if(handler!=null)
            {                                      
                handler(this, new HistoryChangeEventArgs(this.UndoManager.RedoText, this.UndoManager.UndoText));
            }
        }
        #endregion
        
        #region Methods

        public  virtual void RaiseOnToolDeactivate(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = OnToolDeactivate;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public  virtual void RaiseOnShowSelectionProperties(SelectionEventArgs e)
        {
            EventHandler<SelectionEventArgs> handler = OnShowSelectionProperties;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RaiseOnToolActivate(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = OnToolActivate;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RaiseOnMouseDown(MouseEventArgs e)
        {
            if(OnMouseDown != null)
                OnMouseDown(this, e);
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

   




        #region Tool (de)activation methods
        public bool DeactivateTool(ITool tool)
        {
            bool flag = false;
            if (tool != null && tool.Enabled && tool.IsActive)
            {
                //IEnumerator iEnumerator = tools.GetEnumerator();
                //Tool tool2 = null;
                //while (iEnumerator.MoveNext())
                //{
                //    tool2 = iEnumerator.Current is Tool;
                //    if (tool2 != null && tool2 != tool)
                //    {
                //        tool2.ToolDeactivating(tool);
                //    }
                //}
                flag = tool.DeactivateTool();
                if (flag && eventsEnabled)
                {
                    RaiseOnToolDeactivate(new ToolEventArgs(tool));
                }
            }
            return flag;
        }
        public void ActivateTool(string toolName)
        {
            if(!controllerEnabled)
                return;

            //using anonymous method here
            Predicate<ITool> predicate = delegate(ITool tool)
            {
                if (tool.Name.ToLower() == toolName.ToLower())//not case sensitive
                    return true;
                else
                    return false;
            };
            ITool foundTool= this.registeredTools.Find(predicate);
            ActivateTool(foundTool);
        }

        public void SuspendAllTools()
        {
            foreach(ITool tool in this.Tools)
            {
                tool.IsSuspended = true;
            }
        }
        public void UnsuspendAllTools()
        {
            foreach(ITool tool in this.Tools)
            {
                tool.IsSuspended = false;
                ;
            }
        }
        
        private bool ActivateTool(ITool tool)
		{
            if(!controllerEnabled)
                return false;
			bool flag = false;
			if (tool != null && tool.CanActivate)
			{                  
				flag = tool.ActivateTool();
				if (flag && eventsEnabled )
				{
					RaiseOnToolActivate(new ToolEventArgs(tool));
				}
			}
			return flag;
		}
        #endregion
        public void AddTool(ITool tool)
        {
            //add the tool to the collection even if it doesn't attach to anything (yet)
            registeredTools.Add(tool);

            IMouseListener mouseTool = null;
            if ((mouseTool = tool as IMouseListener) != null)
                mouseListeners.Add(mouseTool);                   

            IKeyboardListener keyboardTool = null;
            if ((keyboardTool = tool as IKeyboardListener) != null)
                keyboardListeners.Add(keyboardTool);

            IDragDropListener dragdropTool = null;
            if ((dragdropTool = tool as IDragDropListener) != null)
                dragdropListeners.Add(dragdropTool);
        }

        private void ListenTo(IDiagramControl surface)
        {

            #region Mouse events
            surface.MouseDown += new System.Windows.Forms.MouseEventHandler(surface_MouseDown);
            surface.MouseUp += new System.Windows.Forms.MouseEventHandler(surface_MouseUp);
            surface.MouseMove += new System.Windows.Forms.MouseEventHandler(surface_MouseMove);
            surface.MouseHover += new EventHandler(surface_MouseHover);
            #endregion

            #region Keyboard events
            surface.KeyDown += new System.Windows.Forms.KeyEventHandler(surface_KeyDown);
            surface.KeyUp += new System.Windows.Forms.KeyEventHandler(surface_KeyUp);
            surface.KeyPress += new System.Windows.Forms.KeyPressEventHandler(surface_KeyPress); 
            #endregion

            #region Dragdrop events
            surface.DragDrop += new DragEventHandler(surface_DragDrop);
            surface.DragEnter += new DragEventHandler(surface_DragEnter);
            surface.DragLeave += new EventHandler(surface_DragLeave);
            surface.DragOver += new DragEventHandler(surface_DragOver);
            surface.GiveFeedback += new GiveFeedbackEventHandler(surface_GiveFeedback);
            #endregion
        }

        

      
        #region DragDrop event handlers
        void surface_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (!controllerEnabled)
                return;
            foreach (IDragDropListener listener in dragdropListeners)
            {
                listener.GiveFeedback(e);
            }            
        }
        void surface_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if(!controllerEnabled)
                return;
            foreach (IDragDropListener listener in dragdropListeners)
            {
                listener.OnDragOver(e);
            }            
        }

        void surface_DragLeave(object sender, EventArgs e)
        {
            if(!controllerEnabled)
                return;
            foreach (IDragDropListener listener in dragdropListeners)
            {
                listener.OnDragLeave(e);
            }            
        }

        void surface_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if(!controllerEnabled)
                return;
            foreach (IDragDropListener listener in dragdropListeners)
            {
                listener.OnDragEnter(e);
            }            
        }

        void surface_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if(!controllerEnabled)
                return;
            foreach (IDragDropListener listener in dragdropListeners)
            {
                listener.OnDragDrop(e);
            }            
        }
        #endregion


        #region Keyboard event handlers
        void surface_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            foreach (IKeyboardListener listener in keyboardListeners)
            {
                listener.KeyPress(e);
            }
        }

        void surface_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            foreach (IKeyboardListener listener in keyboardListeners)
            {
                listener.KeyUp(e);
            }
        }

        void surface_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
             foreach (IKeyboardListener listener in keyboardListeners)
            {
                listener.KeyDown(e);
            }
        }
        
        #endregion

        #region Mouse event handlers
        void surface_MouseHover(object sender, EventArgs e)
        {
            //if (eventsEnabled)
            //    RaiseOnMouseHover(e);
            //if (!controllerEnabled)
                return;  
        }
        void surface_MouseDown(object sender, MouseEventArgs e)
        {
            if (eventsEnabled) 
               RaiseOnMouseDown(e);
            if(!controllerEnabled)
                return;            
            this.parentControl.Focus();
            //this selection process will work independently of the tools because
            //some tools need the current selection or hit entity
            //On the other hand, when drawing a simple rectangle for example the selection
            //should be off, so there is an overhead.
            //Selection.CollectEntitiesAt(e.Location);

            //raise the event to give the host the opportunity to show the properties of the selected item(s)
            //Note that if the selection is empty the property grid will show 'nothing'.
            RaiseOnShowSelectionProperties(new SelectionEventArgs(Selection.SelectedItems.ToArray()));

            foreach(IMouseListener listener in mouseListeners)
            {
                listener.MouseDown(e);
            }
        }
        void surface_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(!controllerEnabled)
                return;
            foreach(IMouseListener listener in mouseListeners)
            {
                listener.MouseMove(e);
            }
        }

        void surface_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(!controllerEnabled)
                return;       
            foreach (IMouseListener listener in mouseListeners)
            {
                listener.MouseUp(e);
            }
        }

        
        #endregion

        /*4//
        public void RaiseOnShowContextMenu(EntityMenuEventArgs e)
        {
            EventHandler<EntityMenuEventArgs> handler = OnShowContextMenu;
            if (handler != null)
            {
                handler(this, e);
            }
        }
         */

        public void RaiseOnShowContextMenu(MouseEventArgs e)
        {
            EventHandler<MouseEventArgs> handler = OnShowContextMenu;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void RaiseOnShowContextMenu2(MouseEventArgs e)
        {
            EventHandler<MouseEventArgs> handler = OnShowContextMenu2;
            if (handler != null)
            {
                handler(this, e);
            }
        }




        public void RaiseOnShowObjectMenu(EntityMenuEventArgs e)
        {
            EventHandler<EntityMenuEventArgs> handler = OnShowObjectMenu;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void Undo()
        {
            //reset the tracker or show the tracker after the undo operation since the undo does not take care of it
            this.View.ResetTracker();
            mUndoManager.Undo();
            this.View.ShowTracker();
        }

        public void Redo()
        {
            mUndoManager.Redo();
            this.View.ShowTracker();
        }
        #endregion

        
    }
}
