using Penztargep_dr1_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public class WindowService : IWindowService {
        Window _window;

        public WindowService(Window window) {
            _window = window;
        }

        public void ShowWindow(Window targetView, object viewModel) {
            Window window = targetView;
            window.DataContext = viewModel;
            window.Show();
        }
        public void MinimizeWindow() {
            _window.WindowState = WindowState.Minimized;
        }
        public void ChangeWindowState() {
            if (_window.WindowState == WindowState.Normal) {
                _window.WindowState = WindowState.Maximized;
                return;
            }   
            _window.WindowState = WindowState.Normal;
        }
        public void CloseWindow() {
            _window.Close();
        }


        public ICommand MinimizeWindowCommand => new RelayCommand(
            parameter => {
                if (parameter == null) {
                    this.MinimizeWindow();
                }
            }, parameter => true);

        public ICommand ChangeWindowStateCommand => new RelayCommand(
            parameter => {
                if (parameter == null) {
                    this.ChangeWindowState();
                }
            }, parameter => true);

        public ICommand CloseWindowCommand => new RelayCommand(
            parameter => {
                if (parameter == null) {
                    this.CloseWindow();

                }
            }, parameter => true);
    }
}
