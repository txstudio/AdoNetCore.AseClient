﻿using System;
using System.Collections;

namespace AdoNetCore.AseClient
{
    /// <summary>
    /// Collects all errors generated by Adaptive Server ADO.NET Data Provider.
    /// </summary>
    public sealed class AseErrorCollection : ICollection
    {
        private readonly object _syncRoot = new object();
        private readonly AseError[] _errors;

        internal AseErrorCollection(params AseError[] errors) 
        {
            _errors = errors ?? new AseError[0];
        }

        /// <summary>
        /// The number of errors in the collection.
        /// </summary>
        public int Count => _errors.Length;

        bool ICollection.IsSynchronized => true;

        object ICollection.SyncRoot => _syncRoot;

        /// <summary>
        /// Copies the elements of the AseErrorCollection into an array, starting at the given index within the array.
        /// </summary>
        /// <param name="array">The array into which to copy the elements.</param>
        /// <param name="index">The starting index of the array.</param>
        public void CopyTo(Array array, int index)
        {
            Array.Copy(_errors, 0, array, index, _errors.Length);
        }

        /// <summary>
        /// Enumerates the errors in this collection.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        /// <summary>
        /// The error at the specified index.
        /// </summary>
        public AseError this[int index] 
        {
            get 
            {
                return _errors[index];
            }
        }
    }
}