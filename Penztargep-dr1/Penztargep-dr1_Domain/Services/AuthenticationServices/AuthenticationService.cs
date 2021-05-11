using Microsoft.AspNet.Identity;
using Penztargep_dr1_Domain.Exceptions;
using Penztargep_dr1_Domain.Models;
using System;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services.AuthenticationServices {
    public class AuthenticationService : IAuthenticationService {
        private readonly IUserService _userService;

        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher) {

            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password) {
            User storedUser = await _userService.GetByUsername(username);

            if (storedUser == null) {
                throw new Exception();
            }

            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if (passwordVerificationResult != PasswordVerificationResult.Success) {
                throw new InvalidPasswordException(username, password);
            }

            return storedUser;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword, string firstName, string lastName, string title) {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword) {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            User checkUserExists = await _userService.GetByUsername(username);

            if (checkUserExists != null) {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success) {
                // New employee
                Employee employee = new Employee() {
                    FirstName = firstName,
                    LastName = lastName,
                    Title = title
                };
                // New user
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User() {
                    Username = username,
                    PasswordHash = hashedPassword,
                    Employee = employee
                };

                // Insert into database
                await _userService.Create(user);
            }

            return result;
        }
    }
}
