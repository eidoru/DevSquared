using CommunityToolkit.Mvvm.Input;
using DevSquared.Models;
using DevSquared.Stores;
using System.Diagnostics;
using System.Windows.Input;

namespace DevSquared.ViewModels
{
    public class CoursesViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;

        private readonly List<Course>? _courses;
        public IEnumerable<Course>? Courses => _courses;

        public ICommand EnrollCommand { get; private set; }

        public CoursesViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            _courses = Database.Courses;
            EnrollCommand = new RelayCommand<Course>(OnEnrollCommand);
        }

        private void OnEnrollCommand(Course? course)
        {
            if (Database.CurrentUser == null || Database.CurrentUser.MyCourses == null || course == null) { return; }
            Database.CurrentUser.MyCourses.Add(course);
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
        }
    }
}
