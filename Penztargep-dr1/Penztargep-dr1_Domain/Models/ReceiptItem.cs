using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_Domain.Models {

    public class ReceiptItem : DomainObject {
        public Receipt Receipt { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
