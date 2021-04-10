using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public interface INavigationPenztargepViewModelFactory<T> {
        T CreateViewModel(INavigator navigator);
    }
}
