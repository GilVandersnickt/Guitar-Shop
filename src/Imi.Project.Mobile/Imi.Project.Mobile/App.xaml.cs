using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetupIoC();
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<HomeViewModel>());
        }
        private void SetupIoC()
        {
            //register dependencies
            FreshIOC.Container.Register<IProductService>(new ProductService());
            FreshIOC.Container.Register<IBrandService>(new BrandService());
            FreshIOC.Container.Register<ICategoryService>(new CategoryService());
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
