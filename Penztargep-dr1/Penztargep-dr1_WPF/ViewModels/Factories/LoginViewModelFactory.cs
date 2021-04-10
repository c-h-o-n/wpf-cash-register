using Penztargep_dr1_WPF.State.Authenticators;
using Penztargep_dr1_WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class LoginViewModelFactory : INavigationPenztargepViewModelFactory<LoginViewModel> {
        private readonly IAuthenticator _authenticator;
        private readonly IWindowManager _windowManager;

        public LoginViewModelFactory(IAuthenticator authenticator, IWindowManager windowManager) {
            _authenticator = authenticator;
            _windowManager = windowManager;
        }

        public LoginViewModel CreateViewModel(INavigator navigator) {
            return new LoginViewModel(_authenticator, navigator, _windowManager);
        }
    }
}
