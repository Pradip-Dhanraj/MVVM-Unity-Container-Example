using PCSApplication.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Pages.TappedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RailPage : ContentPage
	{
		public RailPage ()
		{
			InitializeComponent ();
		}
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    MessagingCenter.Subscribe<ExpandableListTemplate, object>(this, "ItemTapped", (sender, arg) =>
        //    {
        //        // do something whenever the "Hi" message is sent
        //        // using the 'arg' parameter which is a string
        //    });

        //}
        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    MessagingCenter.Unsubscribe<ExpandableListTemplate, object>(this, "ItemTapped");

        //}
    }
}