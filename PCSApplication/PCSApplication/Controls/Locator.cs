using Microsoft.Practices.Unity;
using PCSApplication.Services.Dialogs;
using PCSApplication.Services.Navigations;
using PCSApplication.Services.WebServices;
using PCSApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCSApplication.Controls
{
    public class Locator
    {
        private readonly IUnityContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            _container = new UnityContainer();
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IDialogs, Dialogs>();
            _container.RegisterType<IWebServices, WebServices>();
            //_container.RegisterType<IProfileService, ProfileService>();
            //_container.RegisterType<ITVShowsService, TVShowsService>();
            //_container.RegisterType<IWatchingService, WatchingService>();

            _container.RegisterType<OceanViewModel>();
            _container.RegisterType<RailViewModel>();
            _container.RegisterType<RoadViewModel>();
            //_container.RegisterType<MenuViewModel>();
            //_container.RegisterType<MainViewModel>();
            //_container.RegisterType<HomeViewModel>();
        }
        

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
