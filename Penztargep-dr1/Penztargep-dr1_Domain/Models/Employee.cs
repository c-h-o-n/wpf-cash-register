using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class Employee : DomainObject {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}
