using Penztargep_dr1_WPF.State.Navigators;
using System;

namespace Penztargep_dr1_WPF.ViewModels {
    public class RegistrationViewModel : ViewModelBase {
        public String Test { get; set; }
        public IWindowManager WindowManager { get; set; }
        public RegistrationViewModel(IWindowManager windowManager) {
            WindowManager = windowManager;
        }
    }
}
