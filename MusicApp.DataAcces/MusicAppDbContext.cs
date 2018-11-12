using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Model;

namespace MusicApp.DataAcces
{
    public class MusicAppDbContext : DbContext
    {
        public MusicAppDbContext() : base("MusicAppDb")
        {

        }

        public DbSet<Album> Albums {get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
