using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class Category : DomainObject {
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
