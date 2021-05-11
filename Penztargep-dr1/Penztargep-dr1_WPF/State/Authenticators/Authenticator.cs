using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services.AuthenticationServices;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Penztargep_dr1_WPF.State.Authenticators {
    public class Authenticator : IAuthenticator {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }

        public User CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string username, string password) {
            bool success = true;
            try {
                CurrentUser = await _authenticationService.Login(username, password);

            } catch (Exception) {
                success = false;
                Trace.WriteLine("Login failed");
            }

            return success;
        }

        public void Logout() {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword, string firstName, string lastName, string title) {
            return await _authenticationService.Register(username, password, confirmPassword, firstName, lastName, title);
        }
    }
}
