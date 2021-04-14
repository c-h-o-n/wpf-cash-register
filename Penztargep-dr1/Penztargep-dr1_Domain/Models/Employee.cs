using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class Employee : DomainObject {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
