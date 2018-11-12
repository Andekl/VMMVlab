namespace MusicApp.DataAcces.Migrations
{
    using MusicApp.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicApp.DataAcces.MusicAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicApp.DataAcces.MusicAppDbContext context)
        {
            context.Albums.AddOrUpdate(
                n => n.Name,
                new Album { Name = "Wish You Were Here", Band = "Pink Floyd" },
                new Album { Name = "22, A Million", Band = "Bon Iver" },
                new Album { Name = "Kamikaze", Band = "Eminem" }
                );
        }
    }
}
