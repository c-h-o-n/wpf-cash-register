using Microsoft.AspNet.Identity;
using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services.AuthenticationServices {
    public class AuthenticationService : IAuthenticationService {
        private readonly IDataService<Employee> _employeeService;
        private readonly IDataService<User> _userService;

        public AuthenticationService(IDataService<Employee> employeeService, IDataService<User> userService) {
            _employeeService = employeeService;
            _userService = userService;
        }

        public async Task<Employee> Login(string username, string password) {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(string username, string password, string confirmPassword, string firstName, string lastName, string title) {
            if (password != confirmPassword) {
                return false;
            }

            // New employee
            Employee employee = new Employee() {
                FirstName = firstName,
                LastName = lastName,
                Title = title
            };
            // New user
            IPasswordHasher hasher = new PasswordHasher();
            string hashedPassword = hasher.HashPassword(password);

            User user = new User() {
                Username = username,
                PasswordHash = hashedPassword,
                Employee = employee
            };

            // Insert into database
            await _userService.Create(user);


            return true;
        }
    }
}
