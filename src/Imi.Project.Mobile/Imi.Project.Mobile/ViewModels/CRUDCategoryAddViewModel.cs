﻿using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDCategoryAddViewModel : FreshBasePageModel
    {
        private readonly ICategoryService _categoryService;

        public CRUDCategoryAddViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #region Properties
        private Category categoryToAdd;
        public Category CategoryToAdd
        {
            get { return categoryToAdd; }
            set
            {
                categoryToAdd = value;
                RaisePropertyChanged(nameof(CategoryToAdd));
            }
        }
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                RaisePropertyChanged(nameof(CategoryName));
            }
        }
        private ImageSource categoryImageSource;
        public ImageSource CategoryImageSource
        {
            get { return categoryImageSource; }
            set
            {
                categoryImageSource = value;
                RaisePropertyChanged(nameof(CategoryImageSource));
            }
        }
        #endregion
        #region Commands
        public ICommand SaveCategory => new Command(
            async () =>
            {
                if (CategoryName != null)
                {
                    Category newCategory = new Category();
                    newCategory.Id = Guid.NewGuid();
                    newCategory.Name = CategoryName;

                    if (CategoryImageSource != null)
                        newCategory.Image = CategoryImageSource.ToString();
                    else
                        newCategory.Image = "Placeholder.png";

                    var confirmed = await CoreMethods.DisplayAlert("Confirm Add", "Are you sure you want to add this category?", "Yes", "No");
                    if (confirmed)
                    {
                        await _categoryService.Add(newCategory);
                        await CoreMethods.PopModalNavigationService();
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
                    CategoryImageSource = ImageSource.FromStream(() => stream);
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
                    CategoryImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion

    }
}
