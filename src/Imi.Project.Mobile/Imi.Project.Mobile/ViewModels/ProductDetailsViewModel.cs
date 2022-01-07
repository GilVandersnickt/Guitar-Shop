using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ProductDetailsViewModel : FreshBasePageModel
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ProductDetailsViewModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
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
        private Brand brand;
        public Brand Brand
        {
            get { return brand; }
            set
            {
                brand = value;
                RaisePropertyChanged(nameof(Brand));
            }
        }
        private Category category;
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                RaisePropertyChanged(nameof(Category));
            }
        }
        #endregion
        #region Commands
        public ICommand OpenShoppingCartPage => new Command(
            async () =>
            {
                if (SelectedProduct != null)
                    await CoreMethods.PushPageModel<ShoppingCartViewModel>(SelectedProduct);
                else
                    await CoreMethods.DisplayAlert("Error", "No product selected ", "Ok");
            });

        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);

            SelectedProduct = await _productService.Get((initData as Product).Id);
            Brand = await _brandService.Get((initData as Product).BrandId);
            Category = await _categoryService.Get((initData as Product).CategoryId);
        }

    }
}
