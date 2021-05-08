using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.CashRegister {
    public class StateManager : ObservableObject, IStateManager {

        private string _controlButtonText;
        public string ControlButtonText {
            get {
                if (CurrentState) {
                    _controlButtonText = "Pénztár zárása";
                    return _controlButtonText;
                }
                _controlButtonText = "Pénztár nyitása";
                return _controlButtonText;
            } set {
                _controlButtonText = value;
                OnPropertyChanged(nameof(ControlButtonText));
            } 
        }

        private bool _currentState;
        public bool CurrentState {
            get {
                return _currentState;
            }
            set {
                _currentState = value;
                OnPropertyChanged(nameof(CurrentState));
                OnPropertyChanged(nameof(ControlButtonText));
            }
        }
        private ICommand _toggleState;
        public ICommand ToggleState {
            get {
                if (_toggleState == null) {
                    _toggleState = new RelayCommand(
                        parameter => {
                            CurrentState = !CurrentState;
                        },
                        parameter => true);
                }
                return _toggleState;
            }
        }
    }
}
