using Penztargep_dr1_Domain.Services.AuthenticationServices;
using Penztargep_dr1_EntityFramework.Services;
using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Services;
using Penztargep_dr1_WPF.State.Authenticators;
using Penztargep_dr1_WPF.State.Navigators;
using Penztargep_dr1_WPF.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.ViewModels {
    public class LoginViewModel : ViewModelBase {
        public IWindowService WindowService { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public IAuthenticator Authenticator { get; set; }

        private ICommand _loginCommand;
        public ICommand LoginCommand {
            get {
                if (_loginCommand == null) {
                    _loginCommand = new RelayCommand(
                        parameter => this.Login(),
                        parameter => true);
                }
                return _loginCommand;
            }
        }

        private ICommand _RegistrationCommand;
        public ICommand RegistrationCommand {
            get {
                if (_RegistrationCommand == null) {
                    _RegistrationCommand = new RelayCommand(
                        parameter => this.OpenRegistrationWindow(),
                        parameter => true); // TODO: check if reg window is already open
                }
                return _RegistrationCommand;
            }
        }

        private Window _window;

        public LoginViewModel(IAuthenticator authenticator) {
            Authenticator = authenticator;
        }

        //public LoginViewModel(Window window, IAuthenticator authenticator) {
        //    _window = window;
        //    WindowService = new WindowService(window);

        //}

        public async void Login() {
            try {
                await Authenticator.Login(Username, Password);
                Window window = new MainView();
                window.DataContext = new MainViewModel();
                window.Show();
            } catch (Exception) {
                throw new Exception("Login failed.");
            }


            //Window mainWindow = new MainView();
            //WindowService.ShowWindow(mainWindow, new MainViewModel(mainWindow));
            //WindowService.CloseWindow();
        }

        public void OpenRegistrationWindow() {
            Window registrationWindow = new RegistrationView();
            WindowService.ShowWindow(registrationWindow, new RegistrationViewModel(registrationWindow));
        }
    }
}
