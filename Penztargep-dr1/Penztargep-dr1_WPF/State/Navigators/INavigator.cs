using Penztargep_dr1_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public enum ViewType {
        Sale,
        Product,
        Category
    }
    public interface INavigator {
        ViewModelBase CurrentViewModel { get; set;  }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
