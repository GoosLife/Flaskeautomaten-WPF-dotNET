using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flaskeautomaten_WPF_dotNET.Backend
{
    internal class Consumer
    {
        public string Type { get; set; }
        public CancellationToken CancellationToken { get; private set; } = new CancellationTokenSource().Token;
        private Random rng { get; set; } = new Random();

        public Consumer(string type)
        {
            Type = type;
        }

        public void Consume(object obj)
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                Flaskeautomat.Instance.Splitter.Buffers[Type].Take();
                Thread.Sleep(rng.Next(500, 2000));
            }
        }
    }
}
