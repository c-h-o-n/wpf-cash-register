using Penztargep_dr1_WPF.State.Navigators;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class MainViewModelFactory : INavigationPenztargepViewModelFactory<MainViewModel> {
        private readonly IWindowManager _windowManager;
        public MainViewModelFactory(IWindowManager windowManager) {
            _windowManager = windowManager;
        }

        public MainViewModel CreateViewModel(INavigator navigator) {
            return new MainViewModel(navigator, _windowManager);
        }
    }
}
