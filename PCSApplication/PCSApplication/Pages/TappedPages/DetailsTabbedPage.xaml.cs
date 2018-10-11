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
    public partial class DetailsTabbedPage : TabbedPage
    {
        public DetailsTabbedPage ()
        {
            InitializeComponent();
            CurrentPageChanged += DetailsTabbedPage_CurrentPageChanged;
            //DetailsTabbedPage_CurrentPageChanged(this, null);
        }

        private void DetailsTabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var bindabledata = BindingContext as ViewModels.DetailsTabbedViewModel;
            bindabledata.CurrentPage = this.CurrentPage;
        }
    }
}