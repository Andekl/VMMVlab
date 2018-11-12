using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.DataAcces;
using MusicApp.Model;

namespace MusicApp.Data
{
    public class MusicDataService : IMusicDataService
    {
        private Func<MusicAppDbContext> _contextCreator;

        public MusicDataService(Func<MusicAppDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Album> GetByIdAsync(int albumId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Albums.AsNoTracking().SingleAsync(a => a.ID == albumId);
            }
        }

        public async Task SaveAsync(Album album)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Albums.Attach(album);
                ctx.Entry(album).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
