﻿using Penztargep_dr1_WPF.State.Navigators;
using System.Windows;

namespace Penztargep_dr1_WPF.ViewModels {
    public class MainViewModel : ViewModelBase {
        public INavigator Navigator { get; set; }
        public IWindowManager WindowManager { get; set; }

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


        public MainViewModel(INavigator navigator, IWindowManager windowManager) {
            Navigator = navigator;
            WindowManager = windowManager;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Sale);
        }
    }
}
