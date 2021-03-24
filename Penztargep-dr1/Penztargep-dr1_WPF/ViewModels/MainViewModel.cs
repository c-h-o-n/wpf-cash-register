using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Services;
using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.ViewModels {
    public class MainViewModel : ViewModelBase {
        private Window _window;
        public IWindowService WindowService { get; set; }
        public INavigator Navigator { get; set; } = new Navigator();

        // Might need later
        private WindowState _currentWindowState;
        public WindowState CurrentWindowState {
            get {
                return _currentWindowState;
            }
            set {
                _currentWindowState = value;
                base.OnPropertyChanged("CurrentWindowState");
            }
        }

        public MainViewModel(Window window) {
            _window = window;
            WindowService = new WindowService(window);

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Sale);
        }
    }
}
