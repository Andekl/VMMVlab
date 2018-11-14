using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Model;

namespace MusicApp.Data.Lookups
{
    public interface IAlbumLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetAlbumLookupAsync();
    }
}