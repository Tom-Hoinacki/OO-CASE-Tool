using System;

namespace Netron.NetronLight
{
	public interface ICommand
	{
		void Undo();
		void Redo();
		string Text{get; set;}
	}
}
