using Imi.Project.Wpf.ApiModels.Brand;
using Imi.Project.Wpf.ApiModels.Category;
using Imi.Project.Wpf.ApiModels.Subcategory;
using System.Windows.Controls;

namespace Imi.Project.Wpf.Services
{
    public class WpfService
    {
        public BrandApiResponse GetBrandFromComboBox(BrandApiResponse response, ComboBox comboBox)
        {
            foreach (BrandApiResponse brand in comboBox.Items)
            {
                if (response.Id == brand.Id)
                    return brand;
            }
            return null;
        }

        public CategoryApiResponse GetCategoryFromComboBox(CategoryApiResponse response, ComboBox comboBox)
        {
            foreach (CategoryApiResponse category in comboBox.Items)
            {
                if (response.Id == category.Id)
                    return category;
            }
            return null;
        }

        public SubcategoryApiResponse GetSubcategoryFromComboBox(SubcategoryApiResponse response, ComboBox comboBox)
        {
            foreach (SubcategoryApiResponse subcategory in comboBox.Items)
            {
                if (response.Id == subcategory.Id)
                    return subcategory;
            }
            return null;
        }
    }
}
