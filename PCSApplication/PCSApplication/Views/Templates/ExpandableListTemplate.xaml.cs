using PCSApplication.Controls;
using PCSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpandableListTemplate : ContentView
	{
        public int CustomListViewHeight { get; set; }

        public ExpandableListTemplate ()
		{
			InitializeComponent ();
		}

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var bindabledata = BindingContext as SubHomeMenuModel;
            listsubmenu.HeightRequest = bindabledata.submenu.Count * 45;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                listsubmenu.IsVisible = !listsubmenu.IsVisible;
                //if (listsubmenu.Height == 0)
                //{
                //    listsubmenu.HeightRequest = CustomListViewHeight;
                //}
                //else
                //{

                //    //await Task.Run(async () =>
                //    //{
                //    //    while (listsubmenu.HeightRequest != 0)
                //    //    {
                //            //await Task.Delay(01);
                //            listsubmenu.HeightRequest = 0;
                //    //    }
                //    //});


                //    //listsubmenu.HeightRequest = 10;
                //    //ForceLayout();
                //}
            }
            catch (Exception ex)
            {
               
            }
        }

        private void listsubmenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send(this,"ItemTapped", listsubmenu.SelectedItem);
        }
    }
}