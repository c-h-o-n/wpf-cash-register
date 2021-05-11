using Penztargep_dr1_Domain.Services;

namespace Penztargep_dr1_WPF.ViewModels.Factories {
    public class ProductViewModelFactory : IPenztargepViewModelFactory<ProductViewModel> {
        private readonly IProductService _productService;


        public ProductViewModelFactory(IProductService productService) {
            _productService = productService;
        }

        public ProductViewModel CreateViewModel() {
            return new ProductViewModel(_productService);
        }
    }
}
