using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services.AuthenticationServices;
using System;
using System.Threading.Tasks;

namespace Penztargep_dr1_WPF.State.Authenticators {
    public interface IAuthenticator {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <returns>The result of the registration.</returns>
        Task<RegistrationResult> Register(string username, string password, string confirmPassword, string firstName, string lastName, string title);
        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<bool> Login(string username, string password);
        void Logout();
    }
}
