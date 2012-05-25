
using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
namespace Netron.NetronLight
{
    public class UndoManager : IUndoSupport
    {
        public event EventHandler OnHistoryChange;

		#region Fields

        private int       undoLevel;
        private UndoCollection undoList;

        
        private StackBase<CommandInfo>  redoStack;

		#endregion

		#region Constructor
        public UndoManager(int level)
        {
            undoLevel = level;
            undoList = new UndoCollection();
            redoStack = new StackBase<CommandInfo>();
            //the following events are linked in the sense that when an item is popped from the stack it'll be put in the undo collection 
            //again. So, strictly speaking, you need only two of the four events to make the surface aware of the history changes, but
            //we'll keep it as is. It depends on your own perception of the undo/reo process.
            redoStack.OnItemPopped += new EventHandler<CollectionEventArgs<CommandInfo>>(HistoryChanged);
            redoStack.OnItemPushed += new EventHandler<CollectionEventArgs<CommandInfo>>(HistoryChanged);
            undoList.OnItemAdded += new EventHandler<CollectionEventArgs<CommandInfo>>(HistoryChanged);
            undoList.OnItemRemoved += new EventHandler<CollectionEventArgs<CommandInfo>>(HistoryChanged);

        }

     

        private void HistoryChanged(object sender, CollectionEventArgs<CommandInfo> e)
        {
            RaiseHistoryChange();
        }

		#endregion

		#region Properties
        public int MaxUndoLevel
        {
            get
            {
                return undoLevel;
            }
            set
            {
                Debug.Assert( value >= 0 );
				
                // To keep things simple, if you change the undo level,
                // we clear all outstanding undo/redo commands.
                if ( value != undoLevel )
                {
                    ClearUndoRedo();
                    undoLevel = value;
                }
            }
        }

        internal UndoCollection UndoList
        {
            get { return undoList; }
        }
		#endregion

		#region Methods
        private void RaiseHistoryChange()
        {
            if (OnHistoryChange != null)
                OnHistoryChange(this, EventArgs.Empty);
        }
        public void AddUndoCommand(ICommand cmd)
        {
            Debug.Assert( cmd != null );
            Debug.Assert( undoList.Count <= undoLevel );

            if ( undoLevel == 0 )
                return;

            CommandInfo info = null;
            if ( undoList.Count == undoLevel )
            {
                // Remove the oldest entry from the undo list to make room.
                info = (CommandInfo) undoList[0];
                undoList.RemoveAt(0);
            }

            // Insert the new undoable command into the undo list.
            if ( info == null )
                info = new CommandInfo();
            info.Command = cmd;
            info.Handler = null;
            undoList.Add(info);

            // Clear the redo stack.
            ClearRedo();
        }

        public void AddUndoCommand(ICommand cmd, IUndoSupport undoHandler)
        {
            AddUndoCommand(cmd);

            if ( undoList.Count > 0 )
            {
                CommandInfo info = (CommandInfo) undoList[undoList.Count-1];
                Debug.Assert( info != null );
                info.Handler = undoHandler;
            }
        }

        public void ClearUndoRedo()
        {
            ClearUndo();
            ClearRedo();
        }

        public bool CanUndo()
        {
            return undoList.Count > 0;
        }

        public bool CanRedo()
        {
            return redoStack.Count > 0;
        }

        public void Undo()
        {
            if ( !CanUndo() )
                return;
    
            // Remove newest entry from the undo list.
            CommandInfo info = (CommandInfo) undoList[undoList.Count-1];
            undoList.RemoveAt(undoList.Count-1);
            
            // Perform the undo.
            Debug.Assert( info.Command != null );
           
                info.Command.Undo();

            // Now the command is available for redo. Push it onto
            // the redo stack.
            redoStack.Push(info);
        }

        public void Redo()
        {
            if ( !CanRedo() )
                return;
    
            // Remove newest entry from the redo stack.
            CommandInfo info = (CommandInfo) redoStack.Pop();
            
            // Perform the redo.
            Debug.Assert( info.Command != null );
           
                info.Command.Redo();

            // Now the command is available for undo again. Put it back
            // into the undo list.
            undoList.Add(info);
        }

        public string UndoText
        {
            get
            {
                ICommand cmd = NextUndoCommand;
                if (cmd == null)
                    return "";
                return cmd.Text;
            }
        }

        public string RedoText
        {
            get
            {
                ICommand cmd = NextRedoCommand;
                if (cmd == null)
                    return "";
                return cmd.Text;
            }
        }

        public ICommand NextUndoCommand
        {
            get
            {
                if(undoList.Count == 0)
                    return null;
                CommandInfo info = (CommandInfo) undoList[undoList.Count - 1];
                return info.Command;
            }
        }

        public ICommand NextRedoCommand
        {
            get
            {
                if(redoStack.Count == 0)
                    return null;
                CommandInfo info = (CommandInfo) redoStack.Peek();
                return info.Command;
            }

        }

        public ICommand[] GetUndoCommands()
        {
            if ( undoList.Count == 0 )
                return null;

            ICommand[] cmdList = new ICommand[undoList.Count];
            object[] objList = undoList.ToArray();
            for (int i = 0; i < objList.Length; i++)
            {
                CommandInfo info = (CommandInfo) objList[i];
                cmdList[i] = info.Command;
            }

            return cmdList;
        }

        public ICommand[] GetRedoCommands()
        {
            if ( redoStack.Count == 0 )
                return null;

            ICommand[] cmdList = new ICommand[redoStack.Count];
            object[] objList = redoStack.ToArray();
            for (int i = 0; i < objList.Length; i++)
            {
                CommandInfo info = (CommandInfo) objList[i];
                cmdList[i] = info.Command;
            }

            return cmdList;
        }

        private void ClearUndo()
        {
            while( undoList.Count > 0 )
            {
                CommandInfo info = (CommandInfo) undoList[undoList.Count-1];
                undoList.RemoveAt(undoList.Count-1);
                info.Command = null;
                info.Handler = null;
            }
        }

        private void ClearRedo()
        {
            while( redoStack.Count > 0 )
            {
                CommandInfo info = (CommandInfo) redoStack.Pop();
                info.Command = null;
                info.Handler = null;
            }
        }
		#endregion
    }

    class UndoCollection : CollectionBase<CommandInfo>
    {
        
    }
}


