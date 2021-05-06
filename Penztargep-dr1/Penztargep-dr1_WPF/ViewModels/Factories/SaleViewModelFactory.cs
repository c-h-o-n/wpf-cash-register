using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class SaleViewModelFactory : IPenztargepViewModelFactory<SaleViewModel> {
        private readonly IProductService _productService;
        private readonly IDataService<Category> _categoryService;
        private readonly IInputService _inputService;
        private readonly IReceiptService _receiptService;


        public SaleViewModelFactory(IProductService productService, IDataService<Category> categoryService, IInputService saleInputService, IReceiptService receiptService) {
            _productService = productService;
            _categoryService = categoryService;
            _inputService = saleInputService;
            _receiptService = receiptService;
        }

        public SaleViewModel CreateViewModel() {
            return new SaleViewModel(_productService, _categoryService, _inputService, _receiptService);
        }
    }
}
