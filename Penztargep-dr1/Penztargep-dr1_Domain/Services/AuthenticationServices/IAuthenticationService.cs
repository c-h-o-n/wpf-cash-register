using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services.AuthenticationServices {
    public interface IAuthenticationService {
        Task<bool> Register(string username, string password, string confirmPassword, string firstName, string lastName, string title);
        Task<Employee> Login(string username, string password);
    }
}
