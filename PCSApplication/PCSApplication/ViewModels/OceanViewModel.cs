using PCSApplication.Controls;
using PCSApplication.Models;
using PCSApplication.Services.Navigations;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PCSApplication.ViewModels
{
    public class OceanViewModel : ViewModelBase
    {
        private List<SubHomeMenuModel> _datalist;

        public List<SubHomeMenuModel> DataList
        {
            get { return _datalist; }
            set { _datalist = value; OnPropertyChanged(); }
        }

        private INavigationService nav;

        public void SubscribeMessagingCenterMethod()
        {
            Xamarin.Forms.MessagingCenter.Subscribe<Views.Templates.ExpandableListTemplate, object>(this, "ItemTapped", (sender, arg) =>
            {
                // do something whenever the "Hi" message is sent
                // using the 'arg' parameter which is a string
                nav.NavigateToAsync<ItemsDetailsViewModel>(arg);
            });
        }

        public void UnSubscribeMessagingCenterMethod()
        {
            MessagingCenter.Unsubscribe<Views.Templates.ExpandableListTemplate, object>(this, "ItemTapped");
        }

        public OceanViewModel(INavigationService _nav)
        {
            DataList = new List<SubHomeMenuModel>();
            nav = _nav;
        }

    }
}
