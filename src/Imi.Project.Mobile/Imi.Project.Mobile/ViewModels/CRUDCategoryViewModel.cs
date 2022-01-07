using FreshMvvm;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDCategoryViewModel : FreshTabbedNavigationContainer
    {
        public CRUDCategoryViewModel()
        {
            AddTab<CRUDCategoryAddViewModel>("Add", null);
            AddTab<CRUDCategoryUpdateViewModel>("Edit", null);
            AddTab<CRUDCategoryDeleteViewModel>("Delete", null);
        }
    }
}
