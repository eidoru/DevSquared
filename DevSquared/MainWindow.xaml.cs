using DevSquared.ViewModels;
using System.Windows;

namespace DevSquared
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel.CloseCommandEvent += OnCloseEvent;
            MainWindowViewModel.MaximizeCommandEvent += OnMaximizeEvent;
            MainWindowViewModel.MinimizeCommandEvent += OnMinimizeEvent;
            MainWindowViewModel.DragMoveCommandEvent += OnDragMoveEvent;
            InitializeComponent();
        }

        public void OnCloseEvent(object? sender, EventArgs? e)
        {
            Close();
        }

        public void OnMaximizeEvent(object? sender, EventArgs? e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        public void OnMinimizeEvent(object? sender, EventArgs? e)
        {
            WindowState = WindowState.Minimized;
        }

        public void OnDragMoveEvent(object? sender, EventArgs? e)
        {
            DragMove();
        }
    }
}