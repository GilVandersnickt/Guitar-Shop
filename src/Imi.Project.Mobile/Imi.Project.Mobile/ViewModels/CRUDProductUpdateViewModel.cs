﻿using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api;
using Imi.Project.Mobile.Domain.Models.Api.Default;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        private DefaultModelWithImage productBrand;
        public DefaultModelWithImage ProductBrand
        {
            get { return productBrand; }
            set
            {
                productBrand = value;
                RaisePropertyChanged(nameof(ProductBrand));
            }
        }
        private ObservableCollection<DefaultModelWithImage> brands;
        public ObservableCollection<DefaultModelWithImage> Brands
        {
            get { return brands; }
            set
            {
                brands = value;
                RaisePropertyChanged(nameof(Brands));
            }
        }
        private DefaultModelWithImage productCategory;
        public DefaultModelWithImage ProductCategory
        {
            get { return productCategory; }
            set
            {
                productCategory = value;
                RaisePropertyChanged(nameof(ProductCategory));
            }
        }
        private ObservableCollection<DefaultModelWithImage> categories;
        public ObservableCollection<DefaultModelWithImage> Categories
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
        private FileResult productImage;
        public FileResult ProductImage
        {
            get { return productImage; }
            set
            {
                productImage = value;
                RaisePropertyChanged(nameof(ProductImage));
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
                    ProductBrand = Brands.FirstOrDefault(p => p.Id.Equals(ProductToEdit.Brand.Id));
                    ProductCategory = Categories.FirstOrDefault(p => p.Id.Equals(ProductToEdit.Category.Id));
                }
            }
        );

        public ICommand SaveProduct => new Command(
            async () =>
            {
                decimal newPrice;
                if (ProductName != null && decimal.TryParse(ProductPrice, out newPrice))
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this product?", "Yes", "No");
                    if (confirmed)
                    {
                        ProductRequest newProduct = new ProductRequest();
                        newProduct.Id = ProductToEdit.Id;
                        newProduct.Name = ProductName;
                        newProduct.Price = ProductPrice;
                        newProduct.Image = new Uri(ProductToEdit.Image);
                        if (ProductBrand != null)
                            newProduct.BrandId = ProductBrand.Id;
                        else
                            newProduct.BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001");
                        if (ProductCategory != null)
                            newProduct.CategoryId = ProductCategory.Id;
                        else
                            newProduct.CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001");
                        newProduct.SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008");

                        var product = await _productService.Update(newProduct);
                        if(product != null && ProductImage != null)
                            await _productService.AddImage(product.Id, await ProductImage.OpenReadAsync());
                        
                        await CoreMethods.PopModalNavigationService();
                    }
                }
                else
                    await CoreMethods.DisplayAlert("Invalid input", "Enter valid input", "Ok");
            }
        );
        public ICommand TakePhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    ProductImage = result;
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
                    ProductImage = result;
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

            var convertedBrands = new List<DefaultModelWithImage>();
            var convertedCategories = new List<DefaultModelWithImage>();

            foreach (var brand in brands)
                convertedBrands.Add(new DefaultModelWithImage { Id = brand.Id, Name = brand.Name, Image = brand.Image });

            foreach (var category in categories)
                convertedCategories.Add(new DefaultModelWithImage { Id = category.Id, Name = category.Name, Image = category.Image });

            Products = new ObservableCollection<Product>(products);
            Brands = new ObservableCollection<DefaultModelWithImage>(convertedBrands);
            Categories = new ObservableCollection<DefaultModelWithImage>(convertedCategories);
        }
    }
}
