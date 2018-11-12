using MusicApp.Data;
using MusicApp.Event;
using MusicApp.Model;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModel
{
    public class AlbumDetailViewModel : ViewModelBase, IAlbumDetailViewModel
    {
        private IMusicDataService _musicDataService;
        private IEventAggregator _eventAggregator;

        public AlbumDetailViewModel(IMusicDataService musicDataService, IEventAggregator eventAggregator)
        {
            _musicDataService = musicDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenAlbumDetailViewEvent>().Subscribe(OnOpenDetailViewAsync);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            await _musicDataService.SaveAsync(Album);
            _eventAggregator.GetEvent<AfterAlbumSavedEvent>().Publish(
                new AfterAlbumSavedEventArgs
                {
                    ID = Album.ID,
                    DisplayMember = $"{Album.Name} {Album.Band}"
                });
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnOpenDetailViewAsync(int albumId)
        {
            await LoadAsync(albumId);
        }

        public async Task LoadAsync(int albumId)
        {
            Album = await _musicDataService.GetByIdAsync(albumId);
        }

        private Album _album;
        public Album Album { get { return _album; } private set
            {
                _album = value;
                OnPropertChanged();
            }
        }

        public ICommand SaveCommand { get; }
    }
}
