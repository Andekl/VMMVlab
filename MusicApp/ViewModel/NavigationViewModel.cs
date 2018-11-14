using MusicApp.Data;
using MusicApp.Data.Lookups;
using MusicApp.Event;
using MusicApp.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IAlbumLookupDataService _albumLookupDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IAlbumLookupDataService albumLookupDataService, IEventAggregator eventAggregator)
        {
            _albumLookupDataService = albumLookupDataService;
            _eventAggregator = eventAggregator;
            Albums = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterAlbumSavedEvent>().Subscribe(AfterFriedSaved);
        }

        private void AfterFriedSaved(AfterAlbumSavedEventArgs obj)
        {
            var lookupItem = Albums.Single(a => a.Id == obj.ID);
            lookupItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _albumLookupDataService.GetAlbumLookupAsync();
            Albums.Clear();
            foreach (var item in lookup)
            {
                Albums.Add(new NavigationItemViewModel(item.ID, item.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Albums { get; }

    }
}
