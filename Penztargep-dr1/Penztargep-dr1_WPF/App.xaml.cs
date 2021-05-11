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
using Penztargep_dr1_WPF.State.CashRegister;
using Penztargep_dr1_WPF.State.Navigators;
using Penztargep_dr1_WPF.ViewModels;
using Penztargep_dr1_WPF.ViewModels.Factories;
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

            // Database
            services.AddSingleton<PenztargepDbContextFactory>();
            // Login services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();


            // Sale services
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IDataService<Category>, GenericDataService<Category>>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IDataService<Receipt>, GenericDataService<Receipt>>();
            services.AddSingleton<IDataService<ReceiptItem>, GenericDataService<ReceiptItem>>();
            services.AddSingleton<IInputService, InputService>();
            services.AddSingleton<IReceiptService, ReceiptService>();
            services.AddSingleton<IStateManager, StateManager>();
            services.AddSingleton<IDataService<Employee>, GenericDataService<Employee>>();
            services.AddSingleton<IDataService<Product>, GenericDataService<Product>>();
            services.AddSingleton<ISellingService, SellingService>();
            services.AddSingleton<IPdfService, PdfService>();


            // Viewmodels
            services.AddSingleton<IPenztargepViewModelAbstractFactory, PenztargepViewModelAbstractFactory>();
            services.AddSingleton<INavigationPenztargepViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<INavigationPenztargepViewModelFactory<MainViewModel>, MainViewModelFactory>();
            services.AddSingleton<IPenztargepViewModelFactory<SaleViewModel>, SaleViewModelFactory>();
            services.AddSingleton<IPenztargepViewModelFactory<ProductViewModel>, ProductViewModelFactory>();

            services.AddScoped<IWindowManager, WindowManager>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<SaleViewModel>();
            services.AddScoped<RegistrationViewModel>();

            // Views
            services.AddScoped<LoginView>(s => new LoginView(s.GetRequiredService<LoginViewModel>()));
            services.AddScoped<MainView>(s => new MainView(s.GetRequiredService<MainViewModel>()));
            services.AddScoped<RegistrationView>(s => new RegistrationView(s.GetRequiredService<RegistrationViewModel>()));
            services.AddScoped<SaleViewModel>(services => services.GetRequiredService<SaleViewModel>());
            return services.BuildServiceProvider();
        }
    }

}
