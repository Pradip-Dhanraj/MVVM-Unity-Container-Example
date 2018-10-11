using PCSApplication.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PCSApplication.Controls
{
    public class ViewModelBase : BindableObject
    {
        // For this maintenance sample we don't need all Clients project ViewModelBase stuff
        // This is a simplified version
        #region Properties
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public double WidthIndps { get; private set; }
        public double HeightIndps { get; private set; }

        private bool _isactive;

        public bool IsActive
        {
            get { return _isactive; }
            set { _isactive = value; OnPropertyChanged(); }
        }
        #endregion

        public ViewModelBase()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                IsActive = true;
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            var metrics = Xamarin.Essentials.DeviceDisplay.ScreenMetrics;

            // Width (in pixels)
            var widthpixel = metrics.Width;
            var heightpixel = metrics.Height;
            var scale = metrics.Density;
            WidthIndps = (double)((widthpixel - 0.5f) / scale);
            HeightIndps = (double)((heightpixel - 0.5f) / scale);

        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.Profiles;
            if (access == NetworkAccess.Internet)
            {
                IsActive = true;
            }
            else
            {
                IsActive = false;
            }
        }
        
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
