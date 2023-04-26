using Flaskeautomaten_WPF_dotNET.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flaskeautomaten_WPF_dotNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateGUI);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Start();
        }

        private void UpdateGUI(object sender, EventArgs e)
        {
            string bottleTypesString = "";
            foreach (string type in Flaskeautomat.Instance.BottleTypes)
            {
                bottleTypesString += type;
                bottleTypesString += '\n';
            }
            tbBottleTypes.Text = bottleTypesString;

            lblProducer.Content = "Flasker: " + Flaskeautomat.Instance.Buffer.Count;
        }
    }
}
