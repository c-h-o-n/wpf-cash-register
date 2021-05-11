using Microsoft.Extensions.DependencyInjection;
using Penztargep_dr1_WPF.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public class WindowManager : IWindowManager {
        private readonly IServiceProvider _serviceProvider;

        public WindowManager(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public Window Show<T>() where T : Window {
            Window window = _serviceProvider.GetRequiredService<T>();
            window.Show();

            return window;
        }

        public WindowState Minimize(object window) {
            MinimizeWindowCommand.Execute(window);
            Window _window = window as Window;
            return _window.WindowState;
        }

        public WindowState Maximize(object window) {
            Window lWindow = window as Window;
            lWindow.WindowState = WindowState.Maximized;
            return lWindow.WindowState;
        }

        public WindowState Restore(object window) {
            Window lWindow = window as Window;
            lWindow.WindowState = WindowState.Normal;
            return lWindow.WindowState;
        }

        public Window Close(object window) {
            CloseWindowCommand.Execute(window);
            return window as Window;
        }

        public ICommand MinimizeWindowCommand => new RelayCommand(parameter => {
            if (parameter is Window window) {
                window.WindowState = WindowState.Minimized;
            }
        }, parameter => true);

        public ICommand ChangeWindowStateCommand => new RelayCommand(parameter => {
            if (parameter is Window window) {
                if (window.WindowState == WindowState.Normal) {
                    window.WindowState = WindowState.Maximized;
                    return;
                }
                window.WindowState = WindowState.Normal;
            }
        }, parameter => true);

        public ICommand CloseWindowCommand => new RelayCommand(parameter => {
            if (parameter is Window window) {
                window.Close();
            }
        }, parameter => true);
    }
}
