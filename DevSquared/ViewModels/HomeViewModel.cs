using CommunityToolkit.Mvvm.Input;
using DevSquared.Models;
using DevSquared.Stores;
using increment1forms;
using System.Diagnostics;
using System.Windows.Input;

namespace DevSquared.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;

        private List<Course>? _courses;
        public IEnumerable<Course> Courses => _courses!;

        public ICommand OpenCommand { get; set; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            if (Database.CurrentUser != null)
            {
                _courses = Database.CurrentUser!.MyCourses!;
            }
            OpenCommand = new RelayCommand<Course>(OnOpenCommand);
        }

        private void OnOpenCommand(Course? course)
        {
            if (course == null)
            {
                return;
            }
            var winForms = new Form1();
            winForms.Show();
        }
    }
}
