using System.Threading.Tasks;

namespace MusicApp.ViewModel
{
    public interface IAlbumDetailViewModel
    {
        Task LoadAsync(int albumId);
    }
}