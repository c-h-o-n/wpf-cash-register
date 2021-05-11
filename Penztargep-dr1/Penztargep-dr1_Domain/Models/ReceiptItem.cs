using System.ComponentModel.DataAnnotations;

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
