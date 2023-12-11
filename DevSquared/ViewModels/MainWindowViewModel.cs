using CommunityToolkit.Mvvm.Input;
using DevSquared.Stores;
using System.Windows.Input;

namespace DevSquared.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;

        public static event EventHandler? CloseCommandEvent;
        public static event EventHandler? MaximizeCommandEvent;
        public static event EventHandler? MinimizeCommandEvent;
        public static event EventHandler? DragMoveCommandEvent;


        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }
        public ICommand DragMoveCommand { get; private set; }

        public ICommand HomeCommand { get; private set; }
        public ICommand CoursesCommand { get; private set; }
        public ICommand DocumentationCommand { get; private set; }
        public ICommand WorkspaceCommand { get; private set; }
        public ICommand AccountCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public BaseViewModel? CurrentViewModel
        {
            get
            {
                return navigationStore.CurrentViewModel;
            }
        }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.ViewModelChanged += OnViewModelChanged;

            CloseCommand = TitleBarRelayCommand(CloseCommandEvent, this);
            MaximizeCommand = TitleBarRelayCommand(MaximizeCommandEvent, this);
            MinimizeCommand = TitleBarRelayCommand(MinimizeCommandEvent, this);
            DragMoveCommand = TitleBarRelayCommand(DragMoveCommandEvent, this);

            HomeCommand = new RelayCommand(OnHomeCommand);
            CoursesCommand = new RelayCommand(OnCoursesCommand);
            DocumentationCommand = new RelayCommand(OnDocumentationCommand);
            WorkspaceCommand = new RelayCommand(OnWorkspaceCommand);
            AccountCommand = new RelayCommand(OnAccountCommand);
            LogoutCommand = new RelayCommand(OnLogoutCommand);

        }

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnHomeCommand()
        {
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
        }

        private void OnCoursesCommand()
        {
            navigationStore.CurrentViewModel = new CoursesViewModel(navigationStore);
        }

        private void OnDocumentationCommand()
        {
            navigationStore.CurrentViewModel = new DocumentationViewModel(navigationStore);
        }

        private void OnWorkspaceCommand()
        {
            navigationStore.CurrentViewModel = new WorkspaceViewModel(navigationStore);
        }

        private void OnAccountCommand()
        {
            navigationStore.CurrentViewModel = new AccountViewModel(navigationStore);
        }

        private void OnLogoutCommand()
        {
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
        }

        private static RelayCommand TitleBarRelayCommand(EventHandler? eventHandler, object sender)
        {
            return new RelayCommand(() => { eventHandler?.Invoke(sender, EventArgs.Empty); });
        }
    }
}
