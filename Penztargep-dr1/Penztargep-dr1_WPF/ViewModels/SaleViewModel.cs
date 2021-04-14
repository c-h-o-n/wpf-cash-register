using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.ViewModels {

    public class SaleViewModel : ViewModelBase {

        private readonly IProductService _productService;
        private readonly IDataService<Category> _categoryService;

        public ISaleInputService SaleInputService { get; set; }
        public IReceiptService ReceiptService { get; set; }

        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products {
            get { return _products; }
            set { _products = value;
                base.OnPropertyChanged(nameof(Products));
            }
        }
        public  IEnumerable<Category> Categories { get; set; }

        private ICommand _updateCurrentCategoryCommand;
        public ICommand UpdateCurrentCategoryCommand {
            get {
                if (_updateCurrentCategoryCommand == null) {
                    _updateCurrentCategoryCommand = new RelayCommand(
                        parameter => {
                            if (parameter != null) {
                                Task<Category> currentCategory = _categoryService.Get((int)parameter);
                                Products = _productService.GetByCategory(currentCategory.Result).Result;
                            }
                        },
                        parameter => true);
                }
                return _updateCurrentCategoryCommand;
            }
        }


        public SaleViewModel(IProductService productService, IDataService<Category> categoryService, ISaleInputService saleInputService, IReceiptService receiptService) {
            _productService = productService;
            _categoryService = categoryService;
            Categories = _categoryService.GetAll().Result;
            Products = _productService.GetAll().Result;
            SaleInputService = saleInputService;
            ReceiptService = receiptService;


        }

    }
}
