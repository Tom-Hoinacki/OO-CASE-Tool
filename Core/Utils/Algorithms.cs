//******************************
// Written by Peter Golde
// Copyright (connector) 2004-2005, Wintellect
//
// Use and restribution of this code is subject to the license agreement 
// contained in the file "License.txt" accompanying this file.
//******************************

using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 419  // Ambigious cref in XML comment

namespace Netron.NetronLight
{ 

    public static class Algorithms
    {

        public static IEnumerable<T> EnumerableFromArray<T>(T[] array)
        {
            foreach (T t in array)
                yield return t;
        }


      
        #region String representations

        internal static string ToString<T>(IEnumerable<T> collection)
        {
            return ToString(collection);
        }

   

        internal static string ToString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            bool firstItem = true;

            if (dictionary == null)
                return "null";

            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.Append("{");

            // Call ToString on each item and put it in.
            foreach (KeyValuePair<TKey, TValue> pair in dictionary) {
                if (!firstItem)
                    builder.Append(", ");

                if (pair.Key == null)
                    builder.Append("null");
               
                else
                    builder.Append(pair.Key.ToString());

                builder.Append("->");

                if (pair.Value == null)
                    builder.Append("null");
               
                else
                    builder.Append(pair.Value.ToString());


                firstItem = false;
            }

            builder.Append("}");
            return builder.ToString();
        }

        #endregion String representations

  

  

   

        #region Predicate operations

        internal static bool Exists<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (T item in collection) {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        internal static bool TrueForAll<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (T item in collection) {
                if (!predicate(item))
                    return false;
            }

            return true;
        }

        //public static int CountWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
        //{
        //    if (collection == null)
        //        throw new ArgumentNullException("collection");
        //    if (predicate == null)
        //        throw new ArgumentNullException("predicate");

        //    int count = 0;
        //    foreach (T item in collection) {
        //        if (predicate(item))
        //            ++count;
        //    }

        //    return count;
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        internal static ICollection<T> RemoveWhere<T>(ICollection<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
          

            IList<T> list = collection as IList<T>;
            if (list != null) {
                T item;
                int i = -1, j = 0;
                int listCount = list.Count;
                List<T> removed = new List<T>();

                // Remove item where predicate is true, compressing items to lower in the list. This is much more
                // efficient than the naive algorithm that uses IList<T>.Remove().
                while (j < listCount) {
                    item = list[j];
                    if (predicate(item)) {
                        removed.Add(item);
                    }
                    else {
                        ++i;
                        if (i != j)
                            list[i] = item;
                    }
                    ++j;
                }

                ++i;
                if (i < listCount) {
                    // remove items from the end.
                    if (list is IList && ((IList)list).IsFixedSize) {
                        // An array or similar. Null out the last elements.
                        while (i < listCount)
                            list[i++] = default(T);
                    }
                    else {
                        // Normal list.
                        while (i < listCount) {
                            list.RemoveAt(listCount - 1);
                            --listCount;
                        }
                    }
                }

                return removed;
            }
            else {
                // We have to copy all the items to remove to a List, because collections can't be modifed 
                // during an enumeration.
                List<T> removed = new List<T>();

                foreach (T item in collection)
                    if (predicate(item))
                        removed.Add(item);

                foreach (T item in removed)
                    collection.Remove(item);

                return removed;
            }
        }

        //public static IEnumerable<TDest> Convert<TSource, TDest>(IEnumerable<TSource> sourceCollection, Converter<TSource, TDest> converter)
        //{
        //    if (sourceCollection == null)
        //        throw new ArgumentNullException("sourceCollection");
        //    if (converter == null)
        //        throw new ArgumentNullException("converter");

        //    foreach (TSource sourceItem in sourceCollection)
        //        yield return converter(sourceItem);
        //}

        internal static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return GetDictionaryConverter(dictionary, default(TValue));
        }

        internal static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return delegate(TKey key) {
                TValue value;
                if (dictionary.TryGetValue(key, out value))
                    return value;
                else
                    return defaultValue;
            };
        }

        internal static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (action == null)
                throw new ArgumentNullException("action");

            foreach (T item in collection)
                action(item);
        }


        #endregion Predicate operations

     

    }
}
