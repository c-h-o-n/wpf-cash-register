using Penztargep_dr1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public interface IReceiptService {
        void AddItem(ReceiptItem receiptItem);
        ICommand CreateReceiptCommand { get; }
        ICommand CancelReceiptCommand { get; }
        int Total { get; set; }
        String NumberOfItems { get; set; }
        ObservableCollection<ReceiptItem> Items { get; set; }
    }
}
