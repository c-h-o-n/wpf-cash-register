using Penztargep_dr1_WPF.ViewModels;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public enum ViewType {
        Login,
        Registration,
        Main,
        Sale,
        Product,
        Category
    }
    public interface INavigator {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
