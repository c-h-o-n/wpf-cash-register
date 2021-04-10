using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class SaleViewModelFactory : IPenztargepViewModelFactory<SaleViewModel> {

        public SaleViewModel CreateViewModel() {
            return new SaleViewModel();
        }
    }
}
