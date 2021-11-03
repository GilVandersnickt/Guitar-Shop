using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDProductUpdatePage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();
        private readonly ICategoryService categoryService = new CategoryService();
        private readonly IProductService productService = new ProductService();

        public List<Brand> Brands { get => GetBrands(); }
        public List<Category> Categories { get => GetCategories(); }
        public List<Product> Products { get => GetProducts(); }


        public CRUDProductUpdatePage()
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
        private async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            var selectedBrand = ((Button)sender).CommandParameter as Brand;
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imgPhoto.Source = ImageSource.FromStream(() => stream);
            }

        }
        private async void btnUploadPhoto_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please choose an image"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imgPhoto.Source = ImageSource.FromStream(() => stream);
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (pkrProduct.SelectedItem != null)
            {
                Product selectedProduct = (Product)pkrProduct.SelectedItem;
                Product product = productService.Get(selectedProduct.Id).Result;


                var selectedCategory = (Category)pkrCategory.SelectedItem;
                var selectedBrand = (Brand)pkrBrand.SelectedItem;

                product.Id = pkrProduct.Id;
                product.Name = txtProductName.Text;
                product.Price = decimal.Parse(txtPrice.Text);

                if (imgPhoto.Source != null)
                    product.Image = imgPhoto.Source.ToString();
                else
                    product.Image = "";

                product.BrandId = selectedBrand.Id;
                product.CategoryId = selectedCategory.Id;


                await productService.Update(product);
                await Navigation.PopAsync();
            }
        }

        private void pkrProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)pkrProduct.SelectedItem;
            txtProductName.Text = selectedProduct.Name;
            txtPrice.Text = selectedProduct.Price.ToString();
            imgPhoto.Source = selectedProduct.Image;
            pkrBrand.SelectedItem = brandService.Get(selectedProduct.BrandId).Result;
            pkrCategory.SelectedItem = categoryService.Get(selectedProduct.CategoryId).Result;
        }
    }
}