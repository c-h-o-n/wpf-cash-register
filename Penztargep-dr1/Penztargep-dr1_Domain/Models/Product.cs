using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Penztargep_dr1_Domain.Models {
    public class Product : DomainObject {
        [Required]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ReceiptItem> ReceiptItems { get; set; }

    }
}
