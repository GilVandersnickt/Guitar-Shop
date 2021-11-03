using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDCategoryDeletePage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();

        public List<Category> Categories { get => GetCategories(); }

        public CRUDCategoryDeletePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
        }
    }
}