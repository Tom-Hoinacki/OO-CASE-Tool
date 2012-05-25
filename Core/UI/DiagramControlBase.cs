using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
namespace Netron.NetronLight
{
    [  ToolboxItem(false)   ]
    public abstract class DiagramControlBase : ScrollableControl, ISupportInitialize, IDiagramControl
    {

        /*
        Credo...
         
        In des Herzens heilig stille Räume
        Mußt du fliehen aus des Lebens Drang!
        Freiheit ist nur in dem Reich der Träume,
        Und das Schöne blüht nur im Gesang.
        (F.Shiller)
          
         */


        #region Events


        public event EventHandler<PropertiesEventArgs> OnShowProperties;
        public event EventHandler<HistoryChangeEventArgs> OnHistoryChange; 
        protected virtual void RaiseOnShowProperties(PropertiesEventArgs e)
        {
            EventHandler<PropertiesEventArgs> handler = OnShowProperties;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Fields

        private IView mView;
        private IController mController;
        private Document mDocument;
        private bool mEnableAddConnection = true;

       
        #endregion

        #region Properties
        public bool EnableAddConnection
        {
            get { return mEnableAddConnection; }
            set { mEnableAddConnection = value; }
        }
       
        #endregion

        #region Constructor
        protected DiagramControlBase()
        {
            //create the provider for all shapy diagram elements
            ShapeProvider provider = new ShapeProvider();                  
            TypeDescriptor.AddProvider(provider, typeof(SimpleShapeBase));      
        }
        #endregion

        #region Properties
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                //TODO: change the backgroundtype
            }
        }
        //protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        //{
        //    base.OnGiveFeedback(gfbevent);
        //    gfbevent.UseDefaultCursors = false;
        //    Cursor.Current = CursorPallet.DropShape;
        //}
        [Browsable(true), Description("The background color of the canvas if the type is set to 'flat'"), Category("Appearance")]
        public override Color BackColor
        {
            get
            {                
                
                return base.BackColor;
            }
            set
            {
                mDocument.BackColor = value;
                base.BackColor = value;
                this.Invalidate();
            }
        }
        [Browsable(true), Description("The background type"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CanvasBackgroundTypes BackgroundType
        {
            get { return mDocument.BackgroundType; }
            set { mDocument.BackgroundType = value; }
        }
     
        internal IView View
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

        public IController Controller
        {
            get
            {
                return mController;
            }
            set { mController = value; }
            
        }

      
        
        public Document Document
        {
            get { return mDocument; }
           internal set { mDocument = value; }
        }


        #endregion

        #region Methods

        public void NewDiagram()
        {
            this.Controller.Model.Clear();
            this.Invalidate();
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void ActivateTool(string toolName)
        {
            if (toolName == null || toolName.Trim().Length == 0)
                throw new ArgumentNullException("The tool name cannot be 'null' or empty.");

            if(this.Controller == null)
                throw new InconsistencyException("The Controller of the surface is 'null', this is a strong inconsistency in the MVC model.");
            if(toolName.Trim().Length>0)
                this.Controller.ActivateTool(toolName);
        }
 

        public void LaunchTool(string toolName)
        {
            if (this.Controller == null) return;
            this.Controller.ActivateTool(toolName);
        }
                
        

        protected void RaiseOnHistoryChange(HistoryChangeEventArgs e)
        {
            EventHandler<HistoryChangeEventArgs> handler = OnHistoryChange;
            if (handler != null)
            {
                handler(this, e);
            }
        }
   
        
     
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            mView.Paint(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            mView.PaintBackground(pevent.Graphics);
        }

        public void Undo()
        {
            this.Controller.Undo();
        }

        public void Redo()
        {
            this.Controller.Redo();
        }
        #endregion

        #region Explicit ISupportInitialize implementation
        void ISupportInitialize.BeginInit()
        {
            //here you can check the conformity of properties
            BeginInit();
        }

        void ISupportInitialize.EndInit()
        {
            EndInit();
        }

        protected virtual void BeginInit()
        {

        }
        protected virtual void EndInit()
        {
            //necessary if the background type is gradient since the brush requires the size of the client rectangle
            mView.SetBackgroundType(BackgroundType);
        }
        #endregion


       
    }
}
