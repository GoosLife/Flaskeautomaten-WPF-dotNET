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

            // Create labels for each product type
            List<Label> consumerLabels = new List<Label>();

            for (int i = 0; i < Flaskeautomat.Instance.BottleTypes.Count; i++)
            {
                // ViewModel.ConsumerBufferValueIndexes[Flaskeautomat.Instance.BottleTypes[i]] = i;
                ViewModel.ConsumerBufferValues.Add(0);

                // Create new label for each bottle type
                Binding labelBinding = new Binding("ConsumerBufferValues[" + i + "]") { Source = ViewModel.ConsumerBufferValues[i] };
                Label label = new Label()
                {
                    Name = $"lbl{Flaskeautomat.Instance.BottleTypes[i]}",
                    Content = labelBinding.Source,
                    Margin = new Thickness(0, 0, 0, 0)
                };
                consumerLabels.Add(label);
                Grid.Children.Add(label);
            }
        }
    }
}
