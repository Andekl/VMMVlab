using MusicApp.Data;
using MusicApp.Event;
using MusicApp.Model;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IAlbumDetailViewModel _albumDetailViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel, Func<IAlbumDetailViewModel> albumDetailViewModelCreator, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _albumDetailViewModelCreator = albumDetailViewModelCreator;
            _eventAggregator.GetEvent<OpenAlbumDetailViewEvent>().Subscribe(OnOpenDetailViewAsync);

            NavigationViewModel = navigationViewModel;
            //CreateNewAlbumCommand = new DelegateCommand(/*OnCreateNewAlbumExecute*/);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public ICommand CreateNewAlbumCommand { get; }

        private IEventAggregator _eventAggregator;
        private Func<IAlbumDetailViewModel> _albumDetailViewModelCreator;

        public INavigationViewModel NavigationViewModel { get; }

        
        public IAlbumDetailViewModel AlbumDetailViewModel
        {
            get { return _albumDetailViewModel; }
            private set { _albumDetailViewModel = value;
                OnPropertChanged();
            }
        }


        private async void OnOpenDetailViewAsync(int albumId)
        {
            AlbumDetailViewModel = _albumDetailViewModelCreator();
            await AlbumDetailViewModel.LoadAsync(albumId);
        }

        //private async void OnOpenAlbumDetailView(int albumId)
        //{
        //    if(AlbumDetailViewModel != null)
        //    {
        //        var result = _message
        //    }
        //}

        //private void OnCreateNewAlbumExecute()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
