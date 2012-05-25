using System;

namespace Netron.NetronLight
{
    abstract class Command : ICommand
    {

        #region Fields
        private IController mController;

        private string mText = string.Empty;
        #endregion

        #region Properties
        protected IController Controller
        {
            get { return mController; }
            set { mController = value; }
        }
        public virtual string Text
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
            }
        }
        #endregion

        #region Constructor
        protected Command(IController controller)
        {
            if (controller == null)
                throw new InconsistencyException("The controller is 'null'");
            this.mController = controller;
        }
        #endregion

        #region Methods
        public virtual void Undo()
        {
            // Empty implementation.
        }

        public virtual void Redo()
        {
            // Empty implementation.
        }
        #endregion
    }

}
