using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flaskeautomaten_WPF_dotNET
{
    internal class ObservableDictionary<TKey, TValue> : IDictionary, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private Dictionary<TKey, TValue> dictionary;

        public ICollection Keys
        {
            get
            {
                return dictionary.Keys;
            }
        }

        public ICollection Values
        {
            get
            {
                return dictionary.Values;
            }
        }

        public bool IsReadOnly { get; private set; }

        public bool IsFixedSize { get; private set; }

        public int Count { get { return dictionary.Count; } }

        public object SyncRoot { get; private set; }

        public bool IsSynchronized { get; private set; }

        public object this[object key]
        {
            get
            {
                return dictionary[(TKey)key];
            }
            set
            {
                dictionary[(TKey)key] = (TValue)value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            dictionary.Add(key, value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            return;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
