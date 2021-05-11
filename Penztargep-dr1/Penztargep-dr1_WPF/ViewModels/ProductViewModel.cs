using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.ViewModels {
    public class ProductViewModel : ViewModelBase {
        private readonly IProductService _productService;

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products {
            get {
                return _products;
            }
            set {
                _products = value;
                base.OnPropertyChanged(nameof(Products));
            }
        }



        private ICommand _deleteProductCommand;
        public ICommand DeleteProductCommand {
            get {
                if (_deleteProductCommand == null) {
                    _deleteProductCommand = new RelayCommand(
                        parameter => {
                            if (parameter is int code) {
                                Product selectedProduct = _productService.GetByCode(code).Result;
                                _productService.Delete(selectedProduct.Id);

                                Products = new ObservableCollection<Product>(_productService.GetAll().Result);
                            }
                        },
                        parameter => true);
                }
                return _deleteProductCommand;
            }
        }

        private ICommand _updateProductCommand;
        public ICommand UpdateProductCommand {
            get {
                if (_updateProductCommand == null) {
                    _updateProductCommand = new RelayCommand(
                        parameter => {
                            if (parameter is Product updateProduct) {
                                Product selectedProduct = _productService.Get(updateProduct.Id).Result;

                                if (selectedProduct == null) {
                                    _productService.Create(updateProduct);
                                    return;
                                }

                                _productService.Update(selectedProduct.Id, updateProduct);

                                Products = new ObservableCollection<Product>(_productService.GetAll().Result);
                            }
                        },
                        parameter => true);
                }
                return _updateProductCommand;
            }
        }

        private ICommand _createProductCommand;
        public ICommand CreateProductCommand {
            get {
                if (_createProductCommand == null) {
                    _createProductCommand = new RelayCommand(
                        parameter => {
                            Products.Insert(0, new Product());
                            //Products.Add(new Product());
                            base.OnPropertyChanged(nameof(Products));
                        },
                        parameter => true);
                }
                return _createProductCommand;
            }
        }

        public ProductViewModel(IProductService productService) {
            _productService = productService;

            Products = new ObservableCollection<Product>(_productService.GetAll().Result);
        }
    }
}
