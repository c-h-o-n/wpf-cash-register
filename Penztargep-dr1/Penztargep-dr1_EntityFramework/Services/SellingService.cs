using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Penztargep_dr1_EntityFramework.Services {
    public class SellingService : ISellingService {
        private readonly IDataService<Receipt> _receiptService;
        private readonly IDataService<ReceiptItem> _receiptItemService;
        protected readonly PenztargepDbContextFactory _contextFactory;
        public SellingService(IDataService<Receipt> receiptService, IDataService<ReceiptItem> receiptItemService, PenztargepDbContextFactory contextFactory) {
            _receiptService = receiptService;
            _receiptItemService = receiptItemService;
            _contextFactory = contextFactory;
        }

        public async Task<Receipt> SellProducts(Receipt receipt, IEnumerable<ReceiptItem> receiptItems) {

            var createdReceipt = await _receiptService.Create(receipt);
            foreach (var item in receiptItems) {
                item.ReceiptId = createdReceipt.Id;
                item.Product = null;
                await _receiptItemService.Create(item);
            }
            return createdReceipt;
        }
    }
}
