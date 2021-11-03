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
    public partial class CRUDProductAddPage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();
        private readonly ICategoryService categoryService = new CategoryService();
        private readonly IProductService productService = new ProductService();

        public List<Brand> Brands { get => GetBrands(); }
        public List<Category> Categories { get => GetCategories(); }
        public List<Product> Products { get => GetProducts(); }


        public CRUDProductAddPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }
        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
        }
        private List<Product> GetProducts()
        {
            return productService.Get().Result;
        }

    }
}