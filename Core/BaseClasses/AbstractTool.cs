using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Netron.NetronLight
{
    abstract class AbstractTool : ITool
    {

        #region Fields
        private string mName;
        private bool mEnabled = true;
        private IController mController;
        private Cursor mCursor = Cursors.Default;
        private bool mIsActive;
        private Cursor prevCursor ;
        private bool mIsSuspended;
        #endregion

        #region Properties

        public bool IsSuspended
        {
            get { return mIsSuspended; }
            set { mIsSuspended = value; }
        }

        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        internal IController Controller
        {
            get
            {
                return mController;
            }

            set
            {
                mController = value;
            }
        }
        public Cursor Cursor
        {
            get { return mCursor; }
            set { mCursor = value;}
        }

        public bool Enabled
        {
            get
            {
                return this.mEnabled;
            }

            set
            {
                //disable the tool first if it is active
                if (!value && IsActive)
                {                       
                    DeactivateTool();
                }
                mEnabled = value;
            }
        }

        public virtual bool IsExclusive
        {
            get
            {
                return true;
            }
        }

        public virtual bool CanActivate
        {
            get
            {
                if (mEnabled )
                {
                    return !IsActive ;
                }
                else
                {
                    return false;
                }
            }
            
        }
        #endregion

        #region Constructor
        public AbstractTool(string name)
        {
            this.mName = name;
        }
        #endregion

        #region Methods
        protected void RestoreCursor()
        {
            if (prevCursor != null)
            {
                if (Controller != null)
                {
                    Controller.View.CurrentCursor = prevCursor;
                }
                prevCursor = null;
            }
        }
        #region Activation & deactivation

         public bool DeactivateTool()
        {
         
            if (IsActive)
            {
                OnDeactivateTool();
                IsActive = false;
                RestoreCursor();
                UnsuspendTools();
                return true;
            }
            return false;
        }

        public bool ActivateTool()
        {
            //halt other actions
            SuspendOtherTools();
            
            if (Enabled && !IsActive)
            {
                prevCursor = this.Controller.View.CurrentCursor;
                IsActive = true;
                OnActivateTool();
            }
            return IsActive;
        }
        public void SuspendOtherTools()
        {
            foreach (ITool tool in Controller.Tools)
            {
                if (tool != this)
                    tool.IsSuspended = true;
            }
        }
        public void UnsuspendTools()
        {
            foreach (ITool tool in Controller.Tools)
            {                  
               tool.IsSuspended = false;
            }
        }
        #endregion
        protected virtual void OnActivateTool(){}

        protected virtual void OnDeactivateTool(){}

        public object GetService(Type serviceType)
        {
            return null; 
        }
        #endregion

    }
}
