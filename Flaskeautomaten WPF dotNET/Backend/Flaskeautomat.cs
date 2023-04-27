using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten_WPF_dotNET.Backend
{
    internal sealed class Flaskeautomat
    {
        // Singleton implementation

        private static readonly Lazy<Flaskeautomat> flaskeautomat = new Lazy<Flaskeautomat>(() => new Flaskeautomat());
        public static Flaskeautomat Instance => flaskeautomat.Value;
        private Flaskeautomat() {}

        // End of singleton implementation

        public BlockingCollection<Bottle> Buffer = new BlockingCollection<Bottle>();
        public int BufferLimit { get; set; } = 10;
        public List<string> BottleTypes { get; set; } = new List<string>() { "Water", "Beer", "Cola" };
        public Splitter Splitter { get; private set; }
        public List<Consumer> Consumers = new List<Consumer>();
        public Producer Producer = new Producer();

        public void Init()
        {
            Splitter = new Splitter();

            Splitter.PopulateBufferDictionary(BottleTypes);

            CreateConsumers();
            ThreadPool.QueueUserWorkItem(Splitter.Split);
            ThreadPool.QueueUserWorkItem(Producer.Produce);
        }

        private void CreateConsumers()
        {
            foreach (string type in BottleTypes)
            {
                CreateConsumer(type);
            }
        }

        private void CreateConsumer(string type)
        {
            Consumer c = new Consumer(type);
            Consumers.Add(c);

            ThreadPool.QueueUserWorkItem(c.Consume);
        }

        public bool IsInitialized()
        {
            return flaskeautomat == null;
        }
    }
}
