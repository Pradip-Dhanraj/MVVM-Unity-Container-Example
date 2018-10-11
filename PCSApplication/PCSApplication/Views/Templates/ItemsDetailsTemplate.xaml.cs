using PCSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsDetailsTemplate : ContentView
	{
		public ItemsDetailsTemplate ()
		{
			InitializeComponent ();
		}


        private async void TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            await OpenBrowser(new Uri((BindingContext as ItemDetailsModel).linkforpdf));
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            //MessagingCenter.Send(this, "ViewPDF", uri);
        }
    }
}