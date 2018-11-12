using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Model;

namespace MusicApp.Data
{
    public interface IAlbumLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetAlbumLookupAsync();
    }
}