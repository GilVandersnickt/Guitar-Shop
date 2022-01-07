using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public  class AdminViewModel : FreshBasePageModel
    {
        public AdminViewModel()
        {

        }
        #region Commands
        public ICommand OpenCrudBrandPage => new Command(
            async () =>
            {
                var crudBrandPage = new FreshTabbedNavigationContainer("Brand");
                crudBrandPage.AddTab<CRUDBrandAddViewModel>("Add brand", null);
                crudBrandPage.AddTab<CRUDBrandUpdateViewModel>("Edit brand", null);
                crudBrandPage.AddTab<CRUDBrandDeleteViewModel>("Delete brand", null);

                await CoreMethods.PushNewNavigationServiceModal(crudBrandPage);
            }
        );
        public ICommand OpenCrudCategoryPage => new Command(
            async () =>
            {
                var crudCategoryPage = new FreshTabbedNavigationContainer("Category");
                crudCategoryPage.AddTab<CRUDCategoryAddViewModel>("Add category", null);
                crudCategoryPage.AddTab<CRUDCategoryUpdateViewModel>("Edit category", null);
                crudCategoryPage.AddTab<CRUDCategoryDeleteViewModel>("Delete category", null);

                await CoreMethods.PushNewNavigationServiceModal(crudCategoryPage);
            }
        );
        public ICommand OpenCrudProductPage => new Command(
            async () =>
            {
                var crudProductPage = new FreshTabbedNavigationContainer("Product");
                crudProductPage.AddTab<CRUDProductAddViewModel>("Add product", null);
                crudProductPage.AddTab<CRUDProductUpdateViewModel>("Edit product", null);
                crudProductPage.AddTab<CRUDProductDeleteViewModel>("Delete product", null);

                await CoreMethods.PushNewNavigationServiceModal(crudProductPage);
            }
        );
        #endregion
    }
}
