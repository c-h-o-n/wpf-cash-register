using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using Penztargep_dr1_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.Navigators {
    public class Navigator : ObservableObject, INavigator {
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
                if (parameter is ViewType) {
                    ViewType viewType = (ViewType)parameter;
                    switch (viewType) {
                        case ViewType.Sale:
                            CurrentViewModel = new SaleViewModel();
                            break;
                        case ViewType.Product:
                            CurrentViewModel = new ProductViewModel();
                            break;
                        case ViewType.Category:
                            CurrentViewModel = new CategoryViewModel();
                            break;
                        default:
                            break;
                    }
                }
            },
            parameter => true);
    }
}
