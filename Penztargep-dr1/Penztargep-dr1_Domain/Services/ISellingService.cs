using Penztargep_dr1_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface ISellingService {
        Task<Receipt> SellProducts(Receipt receipt, IEnumerable<ReceiptItem> receiptItems);
    }
}
