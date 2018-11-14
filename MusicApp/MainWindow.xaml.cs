using MusicApp.ViewModel;
using System.Windows;

namespace MusicApp.UI
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_LoadedAsync;
        }

        private async void MainWindow_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void AlbumDetailView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
