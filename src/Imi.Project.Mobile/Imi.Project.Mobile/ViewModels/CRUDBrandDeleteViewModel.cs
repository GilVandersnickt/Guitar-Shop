﻿using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDBrandDeleteViewModel : FreshBasePageModel
    {
        private readonly IBrandService brandService;

        public CRUDBrandDeleteViewModel()
        {
            brandService = new BrandService();
        }

        #region Properties
        private Brand brandToDelete;
        public Brand BrandToDelete
        {
            get { return brandToDelete; }
            set
            {
                brandToDelete = value;
                RaisePropertyChanged(nameof(BrandToDelete));
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
        private string brandName;
        public string BrandName
        {
            get { return brandName; }
            set
            {
                brandName = value;
                RaisePropertyChanged(nameof(BrandName));
            }
        }
        #endregion
        #region Commands
        public ICommand DeleteBrand => new Command(
            async () =>
            {
                if (BrandToDelete.Id != null)
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Delete", "Are you sure you want to delete this brand?", "Yes", "No");
                    if(confirmed)
                    {
                        await brandService.Delete(BrandToDelete.Id);
                        await CoreMethods.PopModalNavigationService();
                    }
                }
            }
        );
        #endregion

        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshBrandList();
        }
        private async Task RefreshBrandList()
        {
            var brands = await brandService.Get();
            Brands = new ObservableCollection<Brand>(brands);
        }

    }
}
