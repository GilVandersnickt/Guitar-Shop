﻿using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDProductUpdateViewModel : FreshBasePageModel
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public CRUDProductUpdateViewModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        #region Properties
        private Product productToEdit;
        public Product ProductToEdit
        {
            get { return productToEdit; }
            set
            {
                productToEdit = value;
                RaisePropertyChanged(nameof(ProductToEdit));
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
        public ICommand LoadProduct => new Command(
            () =>
            {
                if (ProductToEdit != null)
                {
                    ProductImageSource = ProductToEdit.Image;
                    ProductName = ProductToEdit.Name;
                    ProductPrice = ProductToEdit.Price.ToString();
                    ProductBrand = Brands.FirstOrDefault(p => p.Id.Equals(ProductToEdit.BrandId));
                    ProductCategory = Categories.FirstOrDefault(p => p.Id.Equals(ProductToEdit.CategoryId));
                }
            }
        );

        public ICommand SaveProduct => new Command(
            async () =>
            {
                if (ProductName != null)
                {
                    decimal newPrice;
                    if (decimal.TryParse(ProductPrice, out newPrice))
                    {
                        Product newProduct = ProductToEdit;
                        newProduct.Name = ProductName;
                        newProduct.Price = newPrice;
                        newProduct.BrandId = ProductBrand.Id;
                        newProduct.CategoryId = ProductCategory.Id;
                        if (ProductImageSource != null)
                            newProduct.Image = ProductImageSource.ToString();
                        else
                            newProduct.Image = "";

                        var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this product?", "Yes", "No");
                        if (confirmed)
                        {
                            await _productService.Update(newProduct);
                            await CoreMethods.PopModalNavigationService();
                        }
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
            var products = await _productService.Get();
            var brands = await _brandService.Get();
            var categories = await _categoryService.Get();
            Products = new ObservableCollection<Product>(products);
            Brands = new ObservableCollection<Brand>(brands);
            Categories = new ObservableCollection<Category>(categories);
        }

    }
}
