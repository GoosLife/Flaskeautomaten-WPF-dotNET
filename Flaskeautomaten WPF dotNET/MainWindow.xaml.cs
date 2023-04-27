using Flaskeautomaten_WPF_dotNET.Backend;
using Flaskeautomaten_WPF_dotNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Flaskeautomaten_WPF_dotNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ViewModel ViewModel { get; private set; } = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
