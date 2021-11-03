using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private readonly IProductService productService = new ProductService();
        public List<Product> Products { get; set; }

        public ProductsPage()
        {
            Products = GetProducts();
            InitializeComponent();
            this.BindingContext = this;
        }
        public ProductsPage(Category category)
        {
            Products = GetProductsByCategory(category);
            InitializeComponent();
            this.BindingContext = this;

        }
        public ProductsPage(Brand brand)
        {
            Products = GetProductsByBrand(brand);
            InitializeComponent();
            this.BindingContext = this;
        }

        private List<Product> GetProducts()
        {
            return productService.Get().Result;
        }
        private List<Product> GetProductsByBrand(Brand brand)
        {
            return productService.GetProductsByBrand(brand).Result;
        }
        private List<Product> GetProductsByCategory(Category category)
        {
            return productService.GetProductsByCategory(category).Result;
        }

        private async void cvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = e.CurrentSelection.FirstOrDefault() as Product;
            if (product == null)
                return;
            await Navigation.PushAsync(new ProductDetailPage(product));
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}