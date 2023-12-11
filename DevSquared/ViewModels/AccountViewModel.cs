using DevSquared.Stores;

namespace DevSquared.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;

        public AccountViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
