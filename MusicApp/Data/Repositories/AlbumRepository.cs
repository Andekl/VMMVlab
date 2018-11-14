using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.DataAcces;
using MusicApp.Model;

namespace MusicApp.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private MusicAppDbContext _context;

        public AlbumRepository(MusicAppDbContext context)
        {
            _context = context;
        }
        public async Task<Album> GetByIdAsync(int albumId)
        {
            return await _context.Albums.SingleAsync(a => a.ID == albumId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
