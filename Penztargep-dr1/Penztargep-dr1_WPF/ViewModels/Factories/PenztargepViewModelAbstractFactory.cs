using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class PenztargepViewModelAbstractFactory : IPenztargepViewModelAbstractFactory {
        private readonly INavigationPenztargepViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly INavigationPenztargepViewModelFactory<MainViewModel> _mainViewModelFactory;

        public PenztargepViewModelAbstractFactory(INavigationPenztargepViewModelFactory<LoginViewModel> loginViewModelFactory, INavigationPenztargepViewModelFactory<MainViewModel> mainViewModelFactory) {
            _loginViewModelFactory = loginViewModelFactory;
            _mainViewModelFactory = mainViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType, INavigator navigator) {
            switch (viewType) {
                case ViewType.Main:
                    return _mainViewModelFactory.CreateViewModel(navigator);
                case ViewType.Sale:
                    return new SaleViewModel();
                case ViewType.Product:
                    return new ProductViewModel();
                case ViewType.Category:
                    return new CategoryViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
