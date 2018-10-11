using PCSApplication.Controls;
using PCSApplication.Models;
using PCSApplication.Pages;
using PCSApplication.Services.Dialogs;
using PCSApplication.Services.Navigations;
using PCSApplication.Services.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCSApplication.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        #region Commands
        public Command NavigatioHomePageCommand { get; set; }
        public Command ShowPasswordCommand { get; set; }

        #endregion

        #region Properties

        private IWebServices webServices;

        private bool _showPass;

        public bool ShowPass
        {
            get { return _showPass; }
            set { _showPass = value; OnPropertyChanged(); }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }


        #endregion

        #region Constructor
        public LoginViewModel(INavigationService _nav,IDialogs _dialogs, IWebServices _webServices)
        {
            Username = "123";
            Password = "123";

            #region Navigate To HomePage
            NavigatioHomePageCommand = new Command(async () => {
                _dialogs.StartLoadingDialoge("Logging in...");
                //Get user data
                var status = await GetUserDataAsync(Username, Password);
                if (status)
                {
                    //Application.Current.MainPage = new DetailsTabbedPage();
                    await _nav.NavigateToAsync<HomeViewModel>();
                }
                else
                {
                    _dialogs.HideLoadingDialogeAsync();
                }
            },()=> {
                return IsActive;
            });

            #endregion

            #region Show Password Command
            ShowPasswordCommand = new Command(() => {
                ShowPass = !ShowPass;
            });
            #endregion

            webServices = _webServices;
        }
        
        #endregion

        #region Login WebService call
        private async System.Threading.Tasks.Task<bool> GetUserDataAsync(string username, string password)
        {
            var _status = await webServices.GetLoginDetailsAsync<UserModel>("{'Password':'123', 'Mpin':'123', 'Name' : '123'}");
            return _status == null ? false : true;
        }
        #endregion

    }
}
