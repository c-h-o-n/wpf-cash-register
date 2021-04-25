using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public interface IPdfService {
        ICommand CreatePDFCommand { get; }
        void CreatePdfReceipt(Receipt receipt, IEnumerable<ReceiptItem> receiptItems);
    }
}
