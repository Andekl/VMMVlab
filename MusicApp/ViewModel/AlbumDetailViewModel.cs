using MusicApp.Data;
using MusicApp.Data.Repositories;
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
        private IAlbumRepository _albumrepository;
        private IEventAggregator _eventAggregator;
        private bool _hasChanges;

        public AlbumDetailViewModel(IAlbumRepository albumrepository, IEventAggregator eventAggregator)
        {
            this._albumrepository = albumrepository;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnSaveExecute()
        {
            await _albumrepository.SaveAsync();
            HasChanges = _albumrepository.HasChanges();
            _eventAggregator.GetEvent<AfterAlbumSavedEvent>().Publish(
                new AfterAlbumSavedEventArgs
                {
                    ID = Album.ID,
                    DisplayMember = $"{Album.Name} {Album.Band}"
                });
        }


        public bool HasChanges
        {
            get { return _hasChanges; }
            set {
                if(_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }                
            }
        }


        private bool OnSaveCanExecute()
        {
            //return Album != null && HasChanges;
            return true;
        }

        public async Task LoadAsync(int albumId)
        {
            Album = await _albumrepository.GetByIdAsync(albumId);
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
