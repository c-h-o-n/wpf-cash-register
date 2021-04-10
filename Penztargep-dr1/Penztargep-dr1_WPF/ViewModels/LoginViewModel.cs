using Penztargep_dr1_Domain.Services.AuthenticationServices;
using Penztargep_dr1_EntityFramework.Services;
using Penztargep_dr1_WPF.Commands;
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
        public INavigator Navigator { get; set; }
        public IWindowManager WindowManager { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IAuthenticator Authenticator { get; set; }

        private ICommand _loginCommand;
        public ICommand LoginCommand {
            get {
                if (_loginCommand == null) {
                    _loginCommand = new RelayCommand(
                        parameter => {
                            this.Login();
                            WindowManager.Show<MainView>();
                            WindowManager.Close(parameter);
                        },
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
                        parameter => WindowManager.Show<RegistrationView>(),
                        parameter => true);; // TODO: check if reg window is already open
                }
                return _RegistrationCommand;
            }
        }

        public LoginViewModel(IAuthenticator authenticator, INavigator navigator, IWindowManager windowManager) {
            Authenticator = authenticator;
            Navigator = navigator;
            WindowManager = windowManager;
        }

        public async void Login() {
            try {
                await Authenticator.Login(Username, Password);
            } catch (Exception) {
                throw new Exception("Login failed.");
            }
        }

        public void OpenRegistrationWindow() {
        }
    }
}
