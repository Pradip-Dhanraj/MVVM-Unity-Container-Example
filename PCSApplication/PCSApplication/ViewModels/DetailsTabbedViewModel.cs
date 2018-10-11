using PCSApplication.Controls;
using PCSApplication.Models;
using PCSApplication.Pages.TappedPages;
using PCSApplication.Services.Dialogs;
using PCSApplication.Services.Navigations;
using PCSApplication.Services.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCSApplication.ViewModels
{
    public class DetailsTabbedViewModel : ViewModelBase
    {
        public OceanViewModel ocean { get; private set; }
        public RailViewModel rail { get; private set; }
        public RoadViewModel road { get; private set; }

        private INavigationService nav;
        private IDialogs dialogs;
        private IWebServices webServices;
        private Page _currentPage;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(); CurrentPageChanged.Invoke(this, new CustomEventArgs("Current page", value)); }
        }

        public HomeMenuModel NavigationData { get; private set; }

        public event EventHandler CurrentPageChanged;

        private Command OceanCommand;
        private Command RailCommand;
        private Command RoadCommand;

        public DetailsTabbedViewModel(INavigationService _nav, IDialogs _dialogs, IWebServices _webServices, OceanViewModel _ocean, RailViewModel _rail, RoadViewModel _road)
        {
            ocean = _ocean;
            rail = _rail;
            road = _road;

            nav = _nav;
            dialogs = _dialogs;
            webServices = _webServices;

            OceanCommand = new Command(()=> { GetDataForOceanAsync(_ocean); });
            RailCommand = new Command(()=> { GetDataForRailAsync(_rail); });
            RoadCommand = new Command(()=> { GetDataForRoadAsync(_road); });
            CurrentPageChanged += DetailsTabbedViewModel_CurrentPageChanged;
            //OceanCommand.Execute(null);
        }
        

        private void DetailsTabbedViewModel_CurrentPageChanged(object sender, EventArgs e)
        {
            var page = (e as CustomEventArgs).Customdata as Page;
            if (page is OceanPage)
            {
                ocean.SubscribeMessagingCenterMethod();
                rail.UnSubscribeMessagingCenterMethod();
                road.UnSubscribeMessagingCenterMethod();
                OceanCommand.Execute(null);
            }
            else if (page is RailPage)
            {
                ocean.UnSubscribeMessagingCenterMethod();
                rail.SubscribeMessagingCenterMethod();
                road.UnSubscribeMessagingCenterMethod();
                RailCommand.Execute(null);
            }
            else if (page is RoadPage)
            {
                ocean.UnSubscribeMessagingCenterMethod();
                rail.UnSubscribeMessagingCenterMethod();
                road.SubscribeMessagingCenterMethod();
                RoadCommand.Execute(null);
            }

        }

        private async void GetDataForRoadAsync(object obj)
        {
            await Task.Run(async () =>
            {
                dialogs.StartLoadingDialoge("Getting Data");
                if (!road.DataList.Any())
                    road.DataList = await webServices.GetListSubHomeMenuAsync<SubHomeMenuModel>(NavigationData.sub_menu[2]);
                await Task.Delay(300);
                dialogs.HideLoadingDialogeAsync();
            });
            
        }

        private async void GetDataForRailAsync(object obj)
        {
            await Task.Run(async () =>
            {
                dialogs.StartLoadingDialoge("Getting Data");
                if (!rail.DataList.Any())
                rail.DataList = await webServices.GetListSubHomeMenuAsync<SubHomeMenuModel>(NavigationData.sub_menu[1]);
                await Task.Delay(300);
                dialogs.HideLoadingDialogeAsync();
            });
        }

        private async void GetDataForOceanAsync(object obj)
        {
            await Task.Run(async () =>
            {
                dialogs.StartLoadingDialoge("Getting Data");
                if (!ocean.DataList.Any())
                ocean.DataList = await webServices.GetListSubHomeMenuAsync<SubHomeMenuModel>(NavigationData.sub_menu[0]);
                await Task.Delay(300);
                dialogs.HideLoadingDialogeAsync();
            });
        }

        public override Task InitializeAsync(object navigationData)
        {
            NavigationData = navigationData as HomeMenuModel;
            ocean.SubscribeMessagingCenterMethod();
            rail.UnSubscribeMessagingCenterMethod();
            road.UnSubscribeMessagingCenterMethod();
            OceanCommand.Execute(null);
            return base.InitializeAsync(navigationData);
        }
    }
}
