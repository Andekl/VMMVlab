using MusicApp.Data;
using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(INavigationViewModel navigationViewModel, IAlbumDetailViewModel albumDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            AlbumDetailViewModel = albumDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IAlbumDetailViewModel AlbumDetailViewModel { get; }

    }
}
