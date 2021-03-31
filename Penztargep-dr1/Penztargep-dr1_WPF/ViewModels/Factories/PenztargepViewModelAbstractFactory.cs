using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class PenztargepViewModelAbstractFactory : IPenztargepViewModelAbstractFactory {
        public ViewModelBase CreateViewModel(ViewType viewType) {
            switch (viewType) {
                //case ViewType.Login:
                //return new LoginViewModel();
                case ViewType.Sale:
                    return new SaleViewModel();
                case ViewType.Product:
                    return new ProductViewModel();
                case ViewType.Category:
                    return new CategoryViewModel();
                    break;
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
