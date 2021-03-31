using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using Penztargep_dr1_EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penztargep_dr1_WPF.ViewModels {

    public class SaleViewModel : ViewModelBase {

        public List<Product> Products { get; set; }
        public List<Category> Categories{ get; set; }


        public SaleViewModel( ) {
            Products = new List<Product>();
            Categories = new List<Category>();
            for (int i = 0; i < 100; i++) {
                Products.Add(new Product() { Code = i, Name = "ProdName" + i });
                Categories.Add(new Category() { Name = "CatName" + i });
            }
           
        }
    }
}
