using PCSApplication.Services.Navigations;
using PCSApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private INavigationService _navigation;

        public LoginPage ( INavigationService navigation)
		{
            _navigation = navigation;
			InitializeComponent ();
		}

        public LoginPage()
        {
            InitializeComponent();
        }
        
        
        protected override bool OnBackButtonPressed()
        {
            return true ;
        }

    }
}