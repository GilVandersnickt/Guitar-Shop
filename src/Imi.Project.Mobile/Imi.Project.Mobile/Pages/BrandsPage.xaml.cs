using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandsPage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();
        public List<Brand> Brands { get => GetBrands(); }
        //public static BindableProperty ItemClickCommandProperty = BindableProperty.Create(nameof(ItemClickCommand), typeof(ICommand), typeof(Brand), null);

        public BrandsPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }

        //public ICommand OpenItemPageCommand => new Command<Brand>(
        //    async (Brand brand) => {              
        //        var productsPage = new ProductsPage(brand);
        //       await Navigation.PushAsync(productsPage, true);
        //    }
        //);

        //public ICommand ItemTapped
        //{
        //    get
        //    {
        //        return new Command((brand) =>
        //        {
        //            var productsPage = new ProductsPage(brand as Brand);
        //            Navigation.PushAsync(productsPage, true);
        //        });
        //    }
        //}
        //private void OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item != null)
        //    {
        //        var brand = e.Item as Brand;
        //        Navigation.PushAsync(new ProductsPage(brand));
        //    }
        //}


        //private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        //{
        //    var test = e.Parameter as Brand;
        //    Navigation.PushAsync(new ProductsPage(test));
        //    //if (e.Item != null)
        //    //{
        //    //var brand = e.Item as Brand;
        //    //Navigation.PushAsync(new ProductsPage(brand));
        //    //}

        //}

        //private void ImageButton_Clicked(object sender, EventArgs e)
        //{

        //    if (e != null)
        //    {
        //        //var brand = e.Item as Brand;
        //        Navigation.PushAsync(new ProductsPage());
        //    }

        //}

        private async void cvBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var brand = e.CurrentSelection.FirstOrDefault() as Brand;
            if (brand == null)
                return;
            await Navigation.PushAsync(new ProductsPage(brand));
            ((CollectionView)sender).SelectedItem = null;
        }

        //public ICommand ItemClickCommand
        //{
        //    get
        //    {
        //        return (ICommand)this.GetValue(ItemClickCommandProperty);
        //    }
        //    set
        //    {
        //        this.SetValue(ItemClickCommandProperty, value);
        //    }
        //}

    }
}