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
    public partial class CRUDProductDeletePage : ContentPage
    {
        private readonly IProductService productService = new ProductService();

        public List<Product> Products { get => GetProducts(); }


        public CRUDProductDeletePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Product> GetProducts()
        {
            return productService.Get().Result;
        }

    }
}