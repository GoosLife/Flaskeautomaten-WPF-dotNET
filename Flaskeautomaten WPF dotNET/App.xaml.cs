using Flaskeautomaten_WPF_dotNET.Backend;
using Flaskeautomaten_WPF_dotNET.Backend.ErrorHandling;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;

namespace Flaskeautomaten_WPF_dotNET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            try
            {
                if (Flaskeautomat.Instance.IsInitialized())
                {
                    throw new FailedToInitializeFlaskeautomatException();
                }
            }
            catch (FailedToInitializeFlaskeautomatException exception)
            {
                MessageBox.Show(exception.Message);
                Application.Current.Shutdown();
            }

            MainWindow window = new MainWindow();
            window.Title = "Flaskeautomaten";
            window.Show();
            Flaskeautomat.Instance.Init();
            }
        }
    }
