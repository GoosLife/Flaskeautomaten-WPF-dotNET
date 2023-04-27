using Flaskeautomaten_WPF_dotNET.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace Flaskeautomaten_WPF_dotNET.Model
{
    public class ViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private int producerBufferCount;
        public int ProducerBufferCount
        {
            get
            {
                return producerBufferCount;
            }
            set
            {
                producerBufferCount = value;
                OnPropertyChanged("ProducerBufferCount");
            }
        }

        // public Dictionary<string, int> ConsumerBufferValueIndexes = new Dictionary<string, int>();

        private ObservableCollection<int> consumerBufferValues = new ObservableCollection<int>();
        public ObservableCollection<int> ConsumerBufferValues
        {
            get
            {
                return consumerBufferValues;
            }
            set
            {
                consumerBufferValues = value;
                OnPropertyChanged("ConsumerBufferValues");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(sender, e);
    }
}