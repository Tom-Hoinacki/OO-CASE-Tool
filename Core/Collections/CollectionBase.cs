
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Netron.NetronLight
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString()}")]
    public class CollectionBase<T> : ICollection<T>, ICollection
    {

        public event EventHandler<CollectionEventArgs<T>> OnItemAdded;
        public event EventHandler<CollectionEventArgs<T>> OnItemRemoved;
        public event EventHandler OnClear;
        List<T> innerList;


        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        #region Constructor
        
        public  CollectionBase()
        {
            innerList = new List<T>();
        }
        #endregion

        public override string ToString()
        {
            return Algorithms.ToString(this);
        }


        #region ICollection<T> Members

        public virtual void Add(T item)
        {
            if(item.Equals(default(T))) return;
            this.innerList.Add(item);
            RaiseOnItemAdded(item);

        }
        public int IndexOf(T item)
        {
            return this.innerList.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            if(item.Equals(default(T)))
                return;
            this.innerList.Insert(index, item);
            RaiseOnItemAdded(item);
        }

        public virtual void AddRange(CollectionBase<T> items)
        {
            this.innerList.AddRange(items);
            //TODO: raise for each item?
        }

        private void RaiseOnItemAdded(T item)
        {
            if (OnItemAdded != null)
                OnItemAdded(this, new CollectionEventArgs<T>(item));
        }

        private void RaiseOnItemRemoved(T item)
        {
            if (OnItemRemoved != null)
                OnItemRemoved(this, new CollectionEventArgs<T>(item));
        }
        private void RaiseOnClear()
        {
            if (OnClear != null)
                OnClear(this, EventArgs.Empty);
        }



        public virtual void Clear()
        {
            RaiseOnClear();
            innerList.Clear();
        }

        public virtual bool Remove(T item)
        {
            
            bool result =  this.innerList.Remove(item);
            if (result)
            {
                RaiseOnItemRemoved(item);
            }
            return result;
        }

        public virtual bool Contains(T item)
        {
            return this.innerList.Contains(item);

        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            int count = this.Count;

            if (count == 0)
                return;

            if (array == null)
                throw new ArgumentNullException("array");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", count, Resource1.ArgumentOutOfRange);
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex", arrayIndex, Resource1.ArgumentOutOfRange);
            if (arrayIndex >= array.Length || count > array.Length - arrayIndex)
                throw new ArgumentException("arrayIndex", Resource1.ArrayTooSmall);

            int index = arrayIndex, i = 0;
            foreach (T item in (ICollection<T>)this)
            {
                if (i >= count)
                    break;

                array[index] = item;
                ++index;
                ++i;
            }
        }

        public virtual T[] ToArray()
        {
            int count = this.Count;

            T[] array = new T[count];
            CopyTo(array, 0);
            return array;
        }

        public int Count { get { return innerList.Count; } }



        #endregion

        #region Delegate operations

        public virtual bool Exists(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Algorithms.Exists(this, predicate);
        }

        public virtual bool TrueForAll(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Algorithms.TrueForAll(this, predicate);
        }

        //public virtual int CountWhere(Predicate<T> predicate)
        //{
        //    if (predicate == null)
        //        throw new ArgumentNullException("predicate");

        //    return Algorithms.CountWhere(this, predicate);
        //}
        public virtual T Find(Predicate<T> predicate)
        {
            foreach (T item in this.innerList)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }


        public virtual ICollection<T> RemoveAll(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Algorithms.RemoveWhere(this, predicate);
        }

        public virtual void ForEach(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            Algorithms.ForEach(this, action);
        }



        #endregion

        #region IEnumerable<T> Members

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }


        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            int count = this.Count;

            if (count == 0)
                return;

            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", index, Resource1.ArgumentOutOfRange);
            if (index >= array.Length || count > array.Length - index)
                throw new ArgumentException("index", Resource1.ArrayTooSmall);

            int i = 0;
            foreach (object o in (ICollection)this)
            {
                if (i >= count)
                    break;

                array.SetValue(o, index);
                ++index;
                ++i;
            }
        }

        bool ICollection.IsSynchronized
        {
            get { return IsSynchronized; }
        }

        protected bool IsSynchronized
        {
            get { return false; }
        }
        object ICollection.SyncRoot
        {
            get { return SyncRoot; }
        }

        protected object SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T item in this)
            {
                yield return item;
            }
        }

        #endregion

        internal string DebuggerDisplayString()
        {
            const int MAXLENGTH = 250;

            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.Append('{');

            // Call ToString on each item and put it in.
            bool firstItem = true;
            foreach (T item in this)
            {
                if (builder.Length >= MAXLENGTH)
                {
                    builder.Append(",...");
                    break;
                }

                if (!firstItem)
                    builder.Append(',');

                if (item == null)
                    builder.Append("null");
                else
                    builder.Append(item.ToString());

                firstItem = false;
            }

            builder.Append('}');
            return builder.ToString();
        }
        public void RemoveAt(int index)
        {
            this.innerList.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return this.innerList[index];
            }
        }
    }

    public class CollectionEventArgs<T> : EventArgs
    {
        private T item;

        public T Item
        {
            get { return item; }
        }
        public CollectionEventArgs(T item)
        {
            this.item = item;
        }
    }
    


    
}
