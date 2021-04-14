using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using Penztargep_dr1_WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public class ReceiptService : ObservableObject, IReceiptService {
        private readonly ISellingService _sellingService;
        private readonly IAuthenticator _authenticator;
        private readonly IDataService<Employee> _employeeService;
        private readonly IDataService<Product> _productService;

        public ReceiptService(ISellingService sellingService, IAuthenticator authenticator, IDataService<Employee> employeeService, IDataService<Product> productService) {
            _sellingService = sellingService;
            _authenticator = authenticator;

            Items = new ObservableCollection<ReceiptItem>();
            _employeeService = employeeService;
            _productService = productService;
        }

        private ObservableCollection<ReceiptItem> _items;
        public ObservableCollection<ReceiptItem> Items {
            get {
                return _items; }
            set { 
                _items = value;
                base.OnPropertyChanged(nameof(Items));

            }
        }


        public async Task<Receipt> Sell() {
            Employee currentEmployee = await _employeeService.Get(_authenticator.CurrentUser.Employee.Id);
            Receipt receipt = new Receipt() {
                Date = DateTime.Now.ToString(),
                Total = this.Total,
                EmployeeId = currentEmployee.Id
            };
            return await _sellingService.SellProducts(receipt, Items);
        } 
        
        public ICommand CreateReceiptCommand => new RelayCommand(
            parameter => {
                Sell();

            }, parameter => true);

        private int _total;
        public int Total { get {
                _total = 0;
                foreach (var item in Items) {
                    _total += item.Total;
                }
                return _total;
            } set {
                _total = value;


            }
        }


        private string _numberOfItems;
        public string NumberOfItems { 
            get {
                _numberOfItems = "Tételszám: " + Items.Count.ToString();
                return _numberOfItems;
            } set {
                _numberOfItems = value;               
            } 
        }

        public ICommand CancelReceiptCommand => new RelayCommand(
            parameter => {
                Items.Clear();
                base.OnPropertyChanged(nameof(Total));
                base.OnPropertyChanged(nameof(NumberOfItems));
            }, parameter => true);

        public void AddItem(ReceiptItem receiptItem) {
            Items.Add(receiptItem);
            foreach (var item in Items) {
                item.Total = item.Quantity * item.Product.Price;
            }
            base.OnPropertyChanged(nameof(Total));
            base.OnPropertyChanged(nameof(NumberOfItems));
        }
    }
}
