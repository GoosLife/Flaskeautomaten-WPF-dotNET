using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten_WPF_dotNET.Backend.ErrorHandling
{
    internal class FailedToInitializeFlaskeautomatException : Exception
    {
        public FailedToInitializeFlaskeautomatException() : base("Failed to initialize Flaskeautomat") {}
    }
}
