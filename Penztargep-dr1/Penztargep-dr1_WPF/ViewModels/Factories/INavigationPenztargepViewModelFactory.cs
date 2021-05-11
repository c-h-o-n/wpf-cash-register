using Penztargep_dr1_WPF.State.Navigators;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public interface INavigationPenztargepViewModelFactory<T> {
        T CreateViewModel(INavigator navigator);
    }
}
