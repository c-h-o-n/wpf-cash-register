using Penztargep_dr1_WPF.Commands;
using Penztargep_dr1_WPF.Models;
using Penztargep_dr1_WPF.Services;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.State.CashRegister {
    public class StateManager : ObservableObject, IStateManager {
        private readonly IReceiptService _receiptService;
        private readonly IPdfService _pdfService;

        private string _controlButtonText;
        public string ControlButtonText {
            get {
                if (CurrentState) {
                    _controlButtonText = "Pénztár zárása";
                    return _controlButtonText;
                }
                _controlButtonText = "Pénztár nyitása";
                return _controlButtonText;
            }
            set {
                _controlButtonText = value;
                OnPropertyChanged(nameof(ControlButtonText));
            }
        }

        private bool _currentState;
        public bool CurrentState {
            get {
                return _currentState;
            }
            set {
                _currentState = value;
                OnPropertyChanged(nameof(CurrentState));
                OnPropertyChanged(nameof(ControlButtonText));
            }
        }
        private ICommand _toggleState;

        public StateManager(IReceiptService receiptService, IPdfService pdfService) {
            _receiptService = receiptService;
            _pdfService = pdfService;
        }

        public ICommand ToggleState {
            get {
                if (_toggleState == null) {
                    _toggleState = new RelayCommand(
                        parameter => {
                            if (_receiptService.Items.Count != 0) {
                                return;
                            }
                            if (CurrentState) {
                                _pdfService.CreatePdfSummary(_receiptService.CurrentSessionReceipts);
                                _receiptService.CurrentSessionReceipts.Clear();
                            }
                            CurrentState = !CurrentState;
                        },
                        parameter => true);
                }
                return _toggleState;
            }
        }
    }
}
