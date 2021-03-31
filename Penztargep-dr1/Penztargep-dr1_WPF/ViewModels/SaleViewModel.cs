using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels {
    public class Product {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class Category {
        public string Name { get; set; }
    }
    public class SaleViewModel : ViewModelBase {
        public List<Product> Products { get; set; }
        public List<Category> Categories{ get; set; }

        public SaleViewModel() {
            Products = new List<Product>();
            Categories = new List<Category>();
            for (int i = 0; i < 100; i++) {
                Products.Add(new Product() { Code = i, Name = "ProdName" + i });
                Categories.Add(new Category() { Name = "CatName" + i });
            }
           
        }
    }
}
