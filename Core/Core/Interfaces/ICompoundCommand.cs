using System;

namespace Netron.NetronLight
{
	public interface ICompoundCommand : ICommand
	{
        CollectionBase<ICommand> Commands
        {
            get;
            set;
        }


	}
}
