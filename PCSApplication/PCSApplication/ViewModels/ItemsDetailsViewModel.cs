using DLToolkit.Forms.Controls;
using PCSApplication.Controls;
using PCSApplication.Models;
using PCSApplication.Services.Navigations;
using PCSApplication.Services.WebServices;
using PCSApplication.Views.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PCSApplication.ViewModels
{
    class ItemsDetailsViewModel : ViewModelBase
    {
        private IWebServices webServices;
        public ICommand GetDataCommand;

        private FlowObservableCollection<ItemDetailsModel> _listOfData;

        public FlowObservableCollection<ItemDetailsModel> ListOfData
        {
            get { return _listOfData; }
            set { _listOfData = value; OnPropertyChanged(); }
        }


        public ItemsDetailsViewModel(IWebServices _webServices, INavigationService _navigationService)
        {
            webServices = _webServices;
            GetDataCommand = new Command(GetDataMethodAsync);
            //MessagingCenter.Subscribe<ItemsDetailsTemplate, Uri>(this, "ViewPDF", (s, e)=> {
            //    _navigationService.NavigateToWithoutViewModel( typeof(PCSApplication.Pages.PdfPage), e);
            //});
        }

        private async void GetDataMethodAsync(object obj)
        {
           var data = await webServices.GetListDetailsAsync<ItemDetailsModel>(obj as string);
            ListOfData = new FlowObservableCollection<ItemDetailsModel>(data);
        }

        public override Task InitializeAsync(object navigationData)
        {
            GetDataCommand.Execute(navigationData as string);
            return base.InitializeAsync(navigationData);
        }
    }
}
