using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Netron.NetronLight
{
    public class StackBase<T>
    {
        #region Fields
		private Stack<T> InnerStack; 
	#endregion

        #region Events
		public event EventHandler<CollectionEventArgs<T>> OnItemPushed;
        public event EventHandler<CollectionEventArgs<T>> OnItemPopped;
	#endregion;

        #region Constructor
		public StackBase()
        {
            InnerStack = new Stack<T>();
        } 
	#endregion

        #region Methods

        public int Count
        {
            get{return InnerStack.Count;}
        }


		public void Push(T item)
        {

            this.InnerStack.Push(item);
            RaiseOnItemPushed(item);

        }

        public T Pop()
        {
            T item=
             InnerStack.Pop();
            RaiseOnItemPopped(item);
            return item;
        }

        public T Peek()
        {
            return InnerStack.Peek();
        }


        public T[] ToArray()
        {
            return InnerStack.ToArray();
        }


        private void RaiseOnItemPushed(T item)
        {
            EventHandler<CollectionEventArgs<T>> handler = OnItemPushed;
            handler(this, new CollectionEventArgs<T>(item));
        }
        private void RaiseOnItemPopped(T item)
        {
            EventHandler<CollectionEventArgs<T>> handler = OnItemPopped;
            handler(this, new CollectionEventArgs<T>(item));
        }

 
	#endregion

    }
}
