using DLToolkit.Forms.Controls;
using PCSApplication.Controls;
using PCSApplication.Models;
using PCSApplication.Services.Dialogs;
using PCSApplication.Services.Navigations;
using PCSApplication.Services.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PCSApplication.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        #region Commands
        public ICommand GetHomeMenu;
        public ICommand HomeMenuTapCommand { get; set; }

        private INavigationService nav;
        private IWebServices webServices;
        private IDialogs dialogs;
        private FlowObservableCollection<HomeMenuModel> _listofmenu;

        public FlowObservableCollection<HomeMenuModel> ListOfMenu
        {
            get { return _listofmenu; }
            set { _listofmenu = value; OnPropertyChanged(); }
        }

        //private object _LastTappedItem;

        //public object LastTappedItem
        //{
        //    get { return _LastTappedItem; }
        //    set { _LastTappedItem = value; }
        //}


        #endregion

        public HomeViewModel(INavigationService _nav,IDialogs _dialogs, IWebServices _webServices)
        {
            nav = _nav;
            webServices = _webServices;
            dialogs = _dialogs;
            HomeMenuTapCommand = new Command(SelectedHomeMenu);
            GetHomeMenu = new Command(GetHomeMenuMethodAsync);
            GetHomeMenu.Execute(null);
        }

        private void SelectedHomeMenu(object obj)
        {
            HomeMenuModel SelectedItem = obj as HomeMenuModel;
            nav.NavigateToAsync<DetailsTabbedViewModel>(SelectedItem);
        }

        private async void GetHomeMenuMethodAsync(object obj)
        {
            dialogs.StartLoadingDialoge("Getting Home Menu");
            var _ListOfMenu = await webServices.GetListHomeMenuAsync<HomeMenuModel>();
            ListOfMenu = new FlowObservableCollection<HomeMenuModel>(_ListOfMenu);
            dialogs.HideLoadingDialogeAsync();
        }
    }
}
