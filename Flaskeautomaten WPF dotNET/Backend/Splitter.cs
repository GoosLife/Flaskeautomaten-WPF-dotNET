using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace Flaskeautomaten_WPF_dotNET.Backend
{
    public class Splitter
    {
        public Dictionary<string, BlockingCollection<Bottle>> Buffers { get; private set; } = new Dictionary<string, BlockingCollection<Bottle>>();
        public CancellationToken CancellationToken { get; private set; } = new CancellationTokenSource().Token;
        private Random rng { get; set; } = new Random();

        public Splitter() {}

        public void Split(object obj)
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                Bottle b = Flaskeautomat.Instance.Buffer.Take();
                Buffers[b.Type].Add(b);
                int viewModelIndex = Flaskeautomat.Instance.BottleTypes.IndexOf(b.Type);
                MainWindow.ViewModel.ConsumerBufferValues[viewModelIndex] = Buffers[b.Type].Count;
                MainWindow.ViewModel.OnPropertyChanged($"ConsumerBufferValues[{viewModelIndex}]");
                Thread.Sleep(rng.Next(500,2000));
            }
        }

        public void PopulateBufferDictionary(List<string> bottleTypes)
        {
            foreach (string type in bottleTypes)
            {
                Buffers.Add(type, new BlockingCollection<Bottle>());
            }
        }
    }
}