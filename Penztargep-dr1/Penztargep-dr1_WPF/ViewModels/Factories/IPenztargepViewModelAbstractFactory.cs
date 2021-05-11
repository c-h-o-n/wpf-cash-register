using Penztargep_dr1_WPF.State.Navigators;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public interface IPenztargepViewModelAbstractFactory {
        ViewModelBase CreateViewModel(ViewType viewType, INavigator navigator);
    }
}
