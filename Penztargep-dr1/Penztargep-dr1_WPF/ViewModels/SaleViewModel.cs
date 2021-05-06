using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Services;
using Penztargep_dr1_WPF.State.CashRegister;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.ViewModels {

    public class SaleViewModel : ViewModelBase {

        private readonly IProductService _productService;
        private readonly IDataService<Category> _categoryService;




        public IInputService InputService { get; set; }
        public IReceiptService ReceiptService { get; set; }
        public IStateManager StateManager { get; set; }

        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products {
            get { return _products; }
            set { _products = value;
                base.OnPropertyChanged(nameof(Products));
            }
        }
        public  IList<Category> Categories { get; set; }


        private ICommand _updateCurrentCategoryCommand;
        public ICommand UpdateCurrentCategoryCommand {
            get {
                if (_updateCurrentCategoryCommand == null) {
                    _updateCurrentCategoryCommand = new RelayCommand(
                        parameter => {
                            if (parameter != null) {
                                Task<Category> currentCategory = _categoryService.Get((int)parameter);
                                Products = _productService.GetByCategory(currentCategory.Result).Result;
                            } else {
                                Products = _productService.GetAll().Result;
                            }
                        },
                        parameter => true);
                }
                return _updateCurrentCategoryCommand;
            }
        }

        public bool IsChecked { get; set; }


        public SaleViewModel(IProductService productService, IDataService<Category> categoryService, IInputService inputService, IReceiptService receiptService, IStateManager stateManager) {
            _productService = productService;
            _categoryService = categoryService;
            InputService = inputService;
            ReceiptService = receiptService;
            StateManager = stateManager;

            Categories = (IList<Category>)_categoryService.GetAll().Result;
            Products = _productService.GetAll().Result;



        }

    }
}
