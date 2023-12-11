using DevSquared.Stores;

namespace DevSquared.ViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;

        public WorkspaceViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
