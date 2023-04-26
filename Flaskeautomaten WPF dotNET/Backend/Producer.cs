using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeautomaten_WPF_dotNET.Backend
{
    internal class Producer
    {
        private Random rng { get; set; } = new Random();
        public CancellationToken CancellationToken { get; private set; } = new CancellationTokenSource().Token;

        public async void Produce(object obj)
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                int randomBottleTypeIndex = rng.Next(0, Flaskeautomat.Instance.BottleTypes.Count);
                string randomType = Flaskeautomat.Instance.BottleTypes[randomBottleTypeIndex];

                Bottle b = new Bottle(randomType);

                // Wait until the flaskeautomat buffer count is less than the buffer limit, then add the bottle to the buffer
                while (Flaskeautomat.Instance.Buffer.Count >= Flaskeautomat.Instance.BufferLimit)
                {
                    await Task.Delay(25);
                }

                Flaskeautomat.Instance.Buffer.Add(b);

                Thread.Sleep(rng.Next(500, 2000)); // Sleep for a random amount of time between 0.5 and 2 seconds
            }
        }


    }
}
