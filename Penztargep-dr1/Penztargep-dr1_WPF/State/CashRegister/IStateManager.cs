using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.CashRegister {
    public interface IStateManager {
        public string ControlButtonText { get; set; }
        public bool CurrentState { get; set; }
        public ICommand ToggleState { get; }
        
    }
}
