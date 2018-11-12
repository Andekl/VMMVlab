using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Event
{
    public class AfterAlbumSavedEvent:PubSubEvent<AfterAlbumSavedEventArgs>
    {

    }

    public class AfterAlbumSavedEventArgs
    {
        public int ID { get; set; }
        public string DisplayMember { get; set; }
    }
}
