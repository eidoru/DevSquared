using DevSquared.Stores;
using DevSquared.ViewModels;
using System.Windows;

namespace DevSquared
{
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;

        public App()
        {
            navigationStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            MainWindow mainWindow = new()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
