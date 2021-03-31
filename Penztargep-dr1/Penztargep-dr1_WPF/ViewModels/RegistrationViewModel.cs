using Penztargep_dr1_WPF.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Penztargep_dr1_WPF.ViewModels {
    public class RegistrationViewModel : ViewModelBase {

        public IWindowService WindowService { get; set; }
        public RegistrationViewModel(Window window) {
            WindowService = new WindowService(window);
        }
    }
}
