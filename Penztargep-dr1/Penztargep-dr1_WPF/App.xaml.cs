using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_Domain.Services.AuthenticationServices;
using Penztargep_dr1_EntityFramework;
using Penztargep_dr1_EntityFramework.Services;
using Penztargep_dr1_WPF.ViewModels;
using Penztargep_dr1_WPF.Views;

namespace Penztargep_dr1_WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            IServiceProvider serviceProvider = CreateServiceProvider();
            IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
            authentication.Register("test", "test", "test", "testFirstName", "testLastName", "testTitle");

            Window window = new LoginView();
            window.DataContext = new LoginViewModel(window);
            window.Show();

            //IAuthenticationService authentication = new AuthenticationService();

            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider() {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            services.AddSingleton<IDataService<Employee>, GenericDataService<Employee>>();
            services.AddSingleton<PenztargepDbContextFactory>();

            return services.BuildServiceProvider();
        }
    }

}
