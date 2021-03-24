using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Services;
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
        private Window _window;
        public IWindowService WindowService { get; set; }

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

        public LoginViewModel(Window window) {
            _window = window;
            WindowService = new WindowService(window);
        }
        // TODO: Add auth
        public void Login() {
            // call backend auth here
            Window mainWindow = new MainView();
            WindowService.ShowWindow(mainWindow, new MainViewModel(mainWindow));
            WindowService.CloseWindow();
        }
    }
}
