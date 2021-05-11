using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Penztargep_dr1_Domain.Services {
    public interface ISellingService {
        /// <summary>
        /// Creates new receipt and receipt items.
        /// </summary>
        /// <param name="receipt"></param>
        /// <param name="receiptItems"></param>
        /// <returns>Created <paramref name="receipt"/>.</returns>
        Task<Receipt> SellProducts(Receipt receipt,  IEnumerable<ReceiptItem> receiptItems);
    }
}
