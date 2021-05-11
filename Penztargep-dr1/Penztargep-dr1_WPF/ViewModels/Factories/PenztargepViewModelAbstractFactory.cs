using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class PenztargepViewModelAbstractFactory : IPenztargepViewModelAbstractFactory {
        private readonly INavigationPenztargepViewModelFactory<MainViewModel> _mainViewModelFactory;
        private readonly IPenztargepViewModelFactory<SaleViewModel> _saleViewModelFactory;
        private readonly IPenztargepViewModelFactory<ProductViewModel> _productViewModelFactory;

        public PenztargepViewModelAbstractFactory(INavigationPenztargepViewModelFactory<LoginViewModel> loginViewModelFactory, INavigationPenztargepViewModelFactory<MainViewModel> mainViewModelFactory, IPenztargepViewModelFactory<SaleViewModel> saleViewModelFactory, IPenztargepViewModelFactory<ProductViewModel> productViewModelFactory) {
            _mainViewModelFactory = mainViewModelFactory;
            _saleViewModelFactory = saleViewModelFactory;
            _productViewModelFactory = productViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType, INavigator navigator) {
            switch (viewType) {
                case ViewType.Main:
                    return _mainViewModelFactory.CreateViewModel(navigator);
                case ViewType.Sale:
                    return _saleViewModelFactory.CreateViewModel();
                case ViewType.Product:
                    return _productViewModelFactory.CreateViewModel(); ;
                case ViewType.Category:
                    return new CategoryViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
