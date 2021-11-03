﻿using Imi.Project.Mobile.Domain.Models;
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
    public partial class CRUDCategoryAddPage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();

        public List<Category> Categories { get => GetCategories(); }

        public CRUDCategoryAddPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
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
            Category newCategory = new Category();
            newCategory.Id = Guid.NewGuid();
            newCategory.Name = txtCategoryName.Text;
            if (imgPhoto.Source != null)
                newCategory.Image = imgPhoto.Source.ToString();
            else
                newCategory.Image = "";
            
            await categoryService.Add(newCategory);
            await Navigation.PopAsync();
        }
    }
}