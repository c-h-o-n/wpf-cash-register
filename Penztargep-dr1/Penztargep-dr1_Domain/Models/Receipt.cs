using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Penztargep_dr1_Domain.Models {

    public class Receipt : DomainObject {
        public string Date { get; set; }
        public int Total { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<ReceiptItem> ReceiptItems { get; set; }
    }
}
