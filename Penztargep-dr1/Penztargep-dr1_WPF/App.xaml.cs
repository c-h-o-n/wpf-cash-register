using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Penztargep_dr1_WPF.ViewModels;
using Penztargep_dr1_WPF.Views;

namespace Penztargep_dr1_WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            Window window = new LoginView();
            window.DataContext = new LoginViewModel(window);
            window.Show();

            base.OnStartup(e);
        }
    }
}
