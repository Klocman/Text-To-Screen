using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Klocman.Extensions;
using Klocman.Tools;

namespace TextToScreen.SongFile
{
    public sealed class SongFileCollection : IDisposable, IEnumerable<SongFileEntry>
    {
        private readonly List<SongFileEntry> _items = new List<SongFileEntry>();
        private bool _collectionWasModified;

        public bool CollectionWasModified
        {
            get { return _collectionWasModified; }
            set
            {
                _collectionWasModified = value;
                if (value)
                    OnCollectionModified();
            }
        }

        public IEnumerable<string> Names
        {
            get { return _items.Select(x => x.Name); }
        }

        public SongFileEntry this[string key]
        {
            get { return _items.FirstOrDefault(x => x.Name.Equals(key)); }
        }

        public void Dispose()
        {
            ItemAdded = null;
            ItemRemoved = null;
            ItemModified = null;
            CollectionModified = null;
            foreach (var item in _items)
            {
                item.ParentCollection = null;
            }
        }

        public IEnumerator<SongFileEntry> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        ///     Fires when items are added or removed from the collection
        /// </summary>
        public event Action<SongFileCollection> CollectionModified;

        public event Action<SongFileCollection, SongFileEntry> ItemAdded;

        /// <summary>
        ///     Fires if any element inside of this collection has been modified
        /// </summary>
        public event Action<SongFileCollection, SongFileEntry> ItemModified;

        public event Action<SongFileCollection, SongFileEntry> ItemRemoved;

        public void Add(SongFileEntry value)
        {
            if (value == null)
                throw new ArgumentNullException();

            value.ParentCollection = this;
            _items.Add(value);
            OnItemAdded(value);
            CollectionWasModified = true;
        }

        public void AddRange(IEnumerable<SongFileEntry> items)
        {
            if (items == null)
                throw new ArgumentNullException();

            var any = false;
            foreach (var item in items)
            {
                item.ParentCollection = this;
                _items.Add(item);
                any = true;
            }

            if (any)
                CollectionWasModified = true;
        }

        /// <summary>
        ///     Automatically renames files if needed
        /// </summary>
        /// <param name="items"></param>
        public void AddRangeSafe(IEnumerable<SongFileEntry> items)
        {
            if (items == null)
                throw new ArgumentNullException();

            AddRange(items.DoForEach(item => item.Name = StringTools.GetUniqueName(item.Name, Names)));
        }

        public void Clear()
        {
            var r = _items.Count > 0;
            _items.Clear();
            if (r)
                CollectionWasModified = true;
        }

        public bool Remove(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            var file = _items.FirstOrDefault(x => x.Name.Equals(name));
            return file != null && Remove(file);
        }

        public bool Remove(SongFileEntry value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var r = _items.Remove(value);
            if (!r)
                return false;

            value.ParentCollection = null;
            CollectionWasModified = true;
            OnItemRemoved(value);

            return true;
        }

        internal void OnItemModified(SongFileEntry key)
        {
            ItemModified?.Invoke(this, key);
        }

        private void OnCollectionModified()
        {
            CollectionModified?.Invoke(this);
        }

        private void OnItemAdded(SongFileEntry key)
        {
            ItemAdded?.Invoke(this, key);
        }

        private void OnItemRemoved(SongFileEntry key)
        {
            ItemRemoved?.Invoke(this, key);
        }
    }
}