using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displaymember;

        public NavigationItemViewModel(int ID, string displaymember)
        {
            Id = ID;
            DisplayMember = displaymember;
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
    }
}
