using DevSquared.ViewModels;

namespace DevSquared.Stores
{
    public class NavigationStore
    {
        public Action? ViewModelChanged;

        private BaseViewModel? _currentViewModel;
        public BaseViewModel? CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                ViewModelChanged?.Invoke();
            }
        }
    }
}
