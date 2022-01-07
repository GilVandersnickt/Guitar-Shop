using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ProductsViewModel : FreshBasePageModel
    {
        private readonly IProductService productService;

        public ProductsViewModel()
        {
            productService = new ProductService();
        }

        #region Properties
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(nameof(SelectedProduct));
            }
        }
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                RaisePropertyChanged(nameof(Products));
            }
        }

        #endregion

        #region Commands
        public ICommand OpenProductDetailsPageCommand => new Command<Product>(
           async (Product product) =>
           {
               await CoreMethods.PushPageModel<ProductDetailsViewModel>(product, false, true);
           }
        );

        #endregion


        public async override void Init(object initData)
        {
            base.Init(initData);
            if(initData.GetType().Equals(typeof(Category)))
                Products = new ObservableCollection<Product>(await productService.GetProductsByCategory(initData as Category));
            if(initData.GetType().Equals(typeof(Brand)))
                Products = new ObservableCollection<Product>(await productService.GetProductsByBrand(initData as Brand));

        }


    }
}
