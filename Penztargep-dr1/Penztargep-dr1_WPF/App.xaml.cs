using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_Domain.Services.AuthenticationServices;
using Penztargep_dr1_EntityFramework;
using Penztargep_dr1_EntityFramework.Services;
using Penztargep_dr1_WPF.Services;
using Penztargep_dr1_WPF.State.Authenticators;
using Penztargep_dr1_WPF.State.Navigators;
using Penztargep_dr1_WPF.ViewModels;
using Penztargep_dr1_WPF.Views;

namespace Penztargep_dr1_WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            IServiceProvider serviceProvider = CreateServiceProvider();


            Window window = serviceProvider.GetRequiredService<LoginView>();
            window.Show();


            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider() {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<PenztargepDbContextFactory>();

            services.AddScoped<LoginViewModel>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<Window>();
            services.AddScoped<IWindowService, WindowService>();

            services.AddScoped<LoginView>(s => new LoginView(s.GetRequiredService<LoginViewModel>()));
            return services.BuildServiceProvider();
        }
    }

}
