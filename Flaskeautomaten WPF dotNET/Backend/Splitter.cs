using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Flaskeautomaten_WPF_dotNET.Backend
{
    public class Splitter
    {
        public Dictionary<string, BlockingCollection<Bottle>> Buffers { get; private set; } = new Dictionary<string, BlockingCollection<Bottle>>();
        public CancellationToken CancellationToken { get; private set; } = new CancellationTokenSource().Token;
        private Random rng { get; set; } = new Random();

        public Splitter() {}

        public async void Split(object obj)
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                Bottle b = Flaskeautomat.Instance.Buffer.Take();
                Buffers[b.Type].Append(b);
                MainWindow.ViewModel.ProducerBufferCount = Flaskeautomat.Instance.Buffer.Count;
                MainWindow.ViewModel.UpdateConsumerBufferValues();
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