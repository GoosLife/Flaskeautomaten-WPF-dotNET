namespace Flaskeautomaten_WPF_dotNET.Backend
{
    public class Bottle
    {
        public string Type { get; private set; }

        public Bottle(string type)
        {
            Type = type;
        }
    }
}