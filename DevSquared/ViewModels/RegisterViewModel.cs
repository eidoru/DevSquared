using CommunityToolkit.Mvvm.Input;
using DevSquared.Models;
using DevSquared.Stores;
using System.Windows;
using System.Windows.Input;

namespace DevSquared.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public ICommand RegisterCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            RegisterCommand = new RelayCommand(OnRegisterCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        private void OnRegisterCommand()
        {
            if (Username == null || Password == null || Username == string.Empty || Password == string.Empty)
            {
                return;
            }
            if (Database.Validate(Username, Password) == false)
            {
                Database.Users.Add(new User(Username, Password));
                navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            }
            else
            {
                MessageBox.Show("User already exists!");

            }
        }

        private void OnCancelCommand()
        {
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
        }
    }
}
