using Imi.Project.Wpf.ApiModels.Base;
using Imi.Project.Wpf.ApiModels.Brand;
using Imi.Project.Wpf.ApiModels.Category;
using Imi.Project.Wpf.ApiModels.Subcategory;
using System.Windows.Controls;

namespace Imi.Project.Wpf.Services
{
    public class WpfService
    {
        public T GetFromComboBox<T>(T response, ComboBox comboBox) where T : BaseApiResponse
        {
            foreach (T entity in comboBox.Items)
            {
                if (response.Id == entity.Id)
                    return entity;
            }
            return null;
        }
    }
}
