using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class User : DomainObject {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public  Employee Employee { get; set; }
    }
}
