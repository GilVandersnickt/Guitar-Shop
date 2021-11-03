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
    public partial class ProductDetailPage : ContentPage
    {
        private readonly IProductService productService = new ProductService();
        public Product ProductDetails { get; set; }

        public ProductDetailPage(Product product)
        {
            ProductDetails = product;
            InitializeComponent();
            this.BindingContext = this;
        }
        public Product GetProduct(Product product)
        {
            return productService.Get(product.Id).Result;
        }

        private void btnCart_Clicked(object sender, EventArgs e)
        {

        }
    }
}