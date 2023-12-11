using DevSquared.Stores;

namespace DevSquared.ViewModels
{
    public class DocumentationViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;

        public DocumentationViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
