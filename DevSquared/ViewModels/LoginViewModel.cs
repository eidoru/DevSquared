using CommunityToolkit.Mvvm.Input;
using DevSquared.Models;
using DevSquared.Stores;
using System.Windows;
using System.Windows.Input;

namespace DevSquared.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            LoginCommand = new RelayCommand(OnLoginCommand);
            RegisterCommand = new RelayCommand(OnRegisterCommand);
        }

        private void OnLoginCommand()
        {
            if (Username == null || Password == null || Username == string.Empty || Password == string.Empty)
            {
                return;
            }
            if (Database.Validate(Username, Password))
            {
                navigationStore.CurrentViewModel = new CoursesViewModel(navigationStore);
                Database.CurrentUser = new User(Username, Password);
            }
            else
            {
                MessageBox.Show("Invalid password!");
            }
        }

        private void OnRegisterCommand()
        {
            navigationStore.CurrentViewModel = new RegisterViewModel(navigationStore);
        }
    }
}
