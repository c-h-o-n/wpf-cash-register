using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Penztargep_dr1_Domain.Models {

    public class ReceiptItem : DomainObject {
        [Required]
        public Receipt Receipt { get; set; }
        public int ReceiptId { get; set; }
        [Required]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Total { get; set; }
    }
}
