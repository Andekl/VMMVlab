using Autofac;
using MusicApp.Data;
using MusicApp.Data.Lookups;
using MusicApp.Data.Repositories;
using MusicApp.DataAcces;
using MusicApp.UI;
using MusicApp.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MusicAppDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<AlbumDetailViewModel>().As<IAlbumDetailViewModel>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();

            return builder.Build();
        }
    }
}
