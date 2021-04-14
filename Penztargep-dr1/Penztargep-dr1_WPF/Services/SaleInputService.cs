using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public class SaleInputService : ObservableObject, ISaleInputService {
        private readonly ISellingService _sellingService;
        private readonly IProductService _productService;
        private readonly IReceiptService _receiptService;
        public SaleInputService(ISellingService sellingService, IProductService productService, IReceiptService receiptService) {
            _sellingService = sellingService;
            _productService = productService;
            _receiptService = receiptService;
            CurrentInput = String.Empty;
        }


        public ICommand InputKeyCommand => new RelayCommand(
            parameter => {
                if (parameter != null && _currentInput != null) {
                    switch ((string)parameter) {
                        case "d":
                            CurrentInput = CurrentInput.Length > 0 ? CurrentInput.Remove(CurrentInput.Length - 1) : String.Empty;
                            break;
                        case "ENTER":
                            var inputs = SplitInput(CurrentInput);
                            int quantity = inputs[1];
                            var product = _productService.Get(inputs[0]).Result;
                            ReceiptItem receiptItem = new ReceiptItem() {
                                Product = product,
                                ProductId = product.Id,
                                Quantity = quantity,
                                Total = quantity * product.Price
                            };

                            _receiptService.AddItem(receiptItem);

                            
                            break;
                        case "c":
                            CurrentInput = "";
                            break;
                        default:
                            CurrentInput += (string)parameter;
                            break;
                    }
                }
            }, paramter => true);

        private string _currentInput;

        public string CurrentInput {
            get { return _currentInput; }
            set {
                _currentInput = value;
                base.OnPropertyChanged(nameof(CurrentInput));
            }
        }

        public int[] SplitInput(string InputString) {
            int[] inputs = new int[2];

            string[] inputSplit = CurrentInput.Split("*");
            if (CurrentInput.Contains("*")) {
                inputs[0] = inputSplit[0] == String.Empty ? 0 : int.Parse(inputSplit[0]);
                inputs[1] = inputSplit[1] == String.Empty ? 1 : int.Parse(inputSplit[1]);
            } else {
                inputs[0] = inputSplit[0] == String.Empty ? 0 : int.Parse(inputSplit[0]);
                inputs[1] = 1;
            }
            return inputs;

        }
    }
}
