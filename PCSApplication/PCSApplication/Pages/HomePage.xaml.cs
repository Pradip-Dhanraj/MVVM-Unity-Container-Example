using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCSApplication.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
    {
        public HomePage ()
		{
            //FlowListView.Init();
            InitializeComponent();
           
            //NavigationPage.SetHasNavigationBar(this, true);
            //NavigationPage.SetTitleIcon(this,"icon.png");


            //var metrics = Xamarin.Essentials.DeviceDisplay.ScreenMetrics;

            //// Orientation (Landscape, Portrait, Square, Unknown)
            //var orientation = metrics.Orientation;

            //// Rotation (0, 90, 180, 270)
            //var rotation = metrics.Rotation;

            //// Width (in pixels)
            //var width = metrics.Width;
            //var height = metrics.Height;
            //var scale = metrics.Density;
            //var dps = (double)((width - 0.5f) / scale);
            
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}