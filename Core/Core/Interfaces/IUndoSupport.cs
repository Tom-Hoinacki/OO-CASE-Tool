using System;

namespace Netron.NetronLight
{
	public interface IUndoSupport
	{
		void Undo();
		void Redo();
	}
}
