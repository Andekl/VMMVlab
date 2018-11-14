using MusicApp.Event;
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
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displaymember;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int ID, string displaymember, IEventAggregator eventAggregator)
        {
            Id = ID;
            DisplayMember = displaymember;
            _eventAggregator = eventAggregator;
            OpenAlbumDetailViewCommand = new DelegateCommand(OnOpenAlbumDetailView);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displaymember; }
            set
            {
                _displaymember = value;
                OnPropertChanged();
            }
        }

        public ICommand OpenAlbumDetailViewCommand { get; }

        private void OnOpenAlbumDetailView()
        {
            _eventAggregator.GetEvent<OpenAlbumDetailViewEvent>().Publish(Id);
        }
    }
}
