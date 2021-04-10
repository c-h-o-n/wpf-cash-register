using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class MainViewModelFactory : INavigationPenztargepViewModelFactory<MainViewModel> {
        private IWindowManager _windowManager;
        public MainViewModelFactory(IWindowManager windowManager) {
            _windowManager = windowManager;
        }

        public MainViewModel CreateViewModel(INavigator navigator) {
            return new MainViewModel(navigator, _windowManager);
        }
    }
}
