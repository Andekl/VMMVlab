using MusicApp.DataAcces;
using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data
{
   public class LookupDataService : IAlbumLookupDataService
    {
        private Func<MusicAppDbContext> _contextCreator;

        public LookupDataService(Func<MusicAppDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetAlbumLookupAsync()
        {
            using(var ctx = _contextCreator())
            {
                return await ctx.Albums.AsNoTracking().Select(a => new LookupItem
                {
                    ID = a.ID,
                    DisplayMember = a.Name + " by " + a.Band
                }).ToListAsync();
            }
        }
    }
}
