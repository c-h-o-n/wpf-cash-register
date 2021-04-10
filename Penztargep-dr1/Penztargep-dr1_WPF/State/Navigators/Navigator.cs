using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using Penztargep_dr1_WPF.ViewModels;
using Penztargep_dr1_WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public class Navigator : ObservableObject, INavigator {
        private readonly IPenztargepViewModelAbstractFactory _viewModelFactory;

        public Navigator(IPenztargepViewModelAbstractFactory viewModelFactory) {
            _viewModelFactory = viewModelFactory;
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel { 
            get {
                return _currentViewModel;
            }
            set {
                _currentViewModel = value;
                base.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new RelayCommand(
            parameter => {
                if (parameter is ViewType viewType) {
                    CurrentViewModel = _viewModelFactory.CreateViewModel(viewType, this);
                }
            },
            parameter => true);
    }
}
