using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class Product : DomainObject {
        public int Code { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
