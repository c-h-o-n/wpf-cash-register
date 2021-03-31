using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public interface IPenztargepViewModelFactory<T> where T : ViewModelBase {
        T CreateViewModel();
    }
}
