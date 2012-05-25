using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    class CompoundCommand : Command, ICompoundCommand
    {
        #region Fields
        private CollectionBase<ICommand> commands;
        #endregion

        #region Properties
        public CollectionBase<ICommand> Commands
        {
            get
            {
                return commands;
            }
            set
            {
                commands = value;
            }
        }

        #endregion
        
        #region Constructor
        public CompoundCommand(IController controller) : base(controller)
        {
            commands = new CollectionBase<ICommand>();
        }
        #endregion

        #region Methods
        public override void Redo()
        {
            foreach(ICommand cmd in commands)
            {
                cmd.Redo();
            }
        }

        public override void Undo()
        {
            foreach(ICommand cmd in commands)
            {
                cmd.Undo();
            }
        }
        #endregion

    }
}
