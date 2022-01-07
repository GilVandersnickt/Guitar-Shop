using FreshMvvm;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDBrandViewModel : FreshTabbedNavigationContainer
    {
        public CRUDBrandViewModel()
        {
            AddTab<CRUDBrandAddViewModel>("Add", null);
            AddTab<CRUDBrandUpdateViewModel>("Edit", null);
            AddTab<CRUDBrandDeleteViewModel>("Delete", null);
        }
    }
}
