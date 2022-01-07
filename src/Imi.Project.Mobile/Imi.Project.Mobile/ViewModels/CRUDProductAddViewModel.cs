using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDProductAddViewModel : FreshBasePageModel
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public CRUDProductAddViewModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        #region Properties
        private Product productToAdd;
        public Product ProductToAdd
        {
            get { return productToAdd; }
            set
            {
                productToAdd = value;
                RaisePropertyChanged(nameof(ProductToAdd));
            }
        }
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                RaisePropertyChanged(nameof(ProductName));
            }
        }
        private string productPrice;
        public string ProductPrice
        {
            get { return productPrice; }
            set
            {
                productPrice = value;
                RaisePropertyChanged(nameof(ProductPrice));
            }
        }
        private Brand productBrand;
        public Brand ProductBrand
        {
            get { return productBrand; }
            set
            {
                productBrand = value;
                RaisePropertyChanged(nameof(ProductBrand));
            }
        }
        private ObservableCollection<Brand> brands;
        public ObservableCollection<Brand> Brands
        {
            get { return brands; }
            set
            {
                brands = value;
                RaisePropertyChanged(nameof(Brands));
            }
        }
        private Category productCategory;
        public Category ProductCategory
        {
            get { return productCategory; }
            set
            {
                productCategory = value;
                RaisePropertyChanged(nameof(ProductCategory));
            }
        }
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                RaisePropertyChanged(nameof(Categories));
            }
        }
        private ImageSource productImageSource;
        public ImageSource ProductImageSource
        {
            get { return productImageSource; }
            set
            {
                productImageSource = value;
                RaisePropertyChanged(nameof(ProductImageSource));
            }
        }
        #endregion
        #region Commands
        public ICommand SaveProduct => new Command(
            async () =>
            {
                if (ProductName != null)
                {
                    decimal newPrice;
                    if (decimal.TryParse(ProductPrice, out newPrice))
                    {

                        Product newProduct = new Product();
                        newProduct.Id = Guid.NewGuid();
                        newProduct.Name = ProductName;
                        newProduct.Price = decimal.Parse(ProductPrice);
                        newProduct.BrandId = ProductBrand.Id;
                        newProduct.CategoryId = ProductCategory.Id;

                        if (ProductImageSource != null)
                            newProduct.Image = ProductImageSource.ToString();
                        else
                            newProduct.Image = "";

                        await _productService.Add(newProduct);
                        await CoreMethods.PopModalNavigationService();
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Invalid price", "Enter a valid price", "Ok");
                    }
                }
            }
        );
        public ICommand TakePhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    ProductImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        public ICommand UploadPhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please choose an image"
                });
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    ProductImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshLists();
        }
        private async Task RefreshLists()
        {
            var brands = await _brandService.Get();
            var categories = await _categoryService.Get();
            Brands = new ObservableCollection<Brand>(brands);
            Categories = new ObservableCollection<Category>(categories);
        }
    }
}
