using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_Domain.Models {

    public class Receipt : DomainObject {
        public string Date { get; set; }
        public int Total { get; set; }
        public Employee Employee { get; set; }
    }
}
