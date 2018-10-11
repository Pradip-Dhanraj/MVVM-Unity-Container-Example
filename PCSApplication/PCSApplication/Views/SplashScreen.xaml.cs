using PCSApplication.Controls;
using PCSApplication.Services.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashScreen : ContentPage
	{

        public SplashScreen ()
		{
			InitializeComponent ();
            
            Device.BeginInvokeOnMainThread(() =>
            {
                Task.Run(async () =>
                {
                    await Task.Run(async () =>
                    {
                        //activity.IsRunning = true;
                        await Task.Delay(4000);
                        //activity.IsRunning = false;
                        while (this.Opacity != 0)
                        {
                            await Task.Delay(20);
                            this.Opacity -= 0.01;
                        }
                        //Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new MainPage());
                        await InitNavigation();
                    });
                });
            });
        }

        private Task InitNavigation()
        {
           var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
            //MainPage = new Controls.CustomNavigationPage(new Views.DemoView());
            //return Task.FromResult(true);
        }
    }
}