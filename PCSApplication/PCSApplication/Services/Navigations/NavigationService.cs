using PCSApplication.Controls;
using PCSApplication.Pages;
using PCSApplication.Pages.TappedPages;
using PCSApplication.ViewModels;
using PCSApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCSApplication.Services.Navigations
{
    public partial class NavigationService : INavigationService
    {

        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            //if (await _authenticationService.UserIsAuthenticatedAndValidAsync())
            //{
            //    await NavigateToAsync<MainViewModel>();
            //}
            //else
            //{
            //    await NavigateToAsync<LoginViewModel>();
            //}

            await NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is HomePage)
            {
                //var mainPage = CurrentApplication.MainPage as MainView;
                //await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as HomePage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            NavigationPage.SetHasNavigationBar(page, false);
            if (page is DetailsTabbedPage || page is ItemsDetailsPage)
            {
                NavigationPage.SetHasNavigationBar(page, true);
                (CurrentApplication.MainPage as CustomNavigationPage).BarBackgroundColor = Color.FromHex(Application.Current.Resources["NavigationBarColor"] as string);
                //(CurrentApplication.MainPage as CustomNavigationPage).Title = "Mode of Transport";
                //(CurrentApplication.MainPage as CustomNavigationPage).BarTextColor = Color.White;
            }
            
            if (page is LoginPage )
            {
                CurrentApplication.MainPage = new CustomNavigationPage(page);
            }else if (page is HomePage)
            {
                //var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;
                //if (_loginpage != null)
                //{
                //    navigationPage.Navigation.InsertPageBefore(page, _loginpage);
                //    await navigationPage.PopAsync();
                //    _loginpage = null;
                //}
                //else
                //{
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                //}
            
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            
            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = Locator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            _mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            _mappings.Add(typeof(DetailsTabbedViewModel), typeof(DetailsTabbedPage));
            _mappings.Add(typeof(ItemsDetailsViewModel), typeof(ItemsDetailsPage));
            //_mappings.Add(typeof(BookingViewModel), typeof(BookingView));
            //_mappings.Add(typeof(CheckoutViewModel), typeof(CheckoutView));
            //_mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            //_mappings.Add(typeof(MainViewModel), typeof(MainView));
            //_mappings.Add(typeof(MyRoomViewModel), typeof(MyRoomView));
            //_mappings.Add(typeof(NotificationsViewModel), typeof(NotificationsView));
            //_mappings.Add(typeof(OpenDoorViewModel), typeof(OpenDoorView));
            //_mappings.Add(typeof(SettingsViewModel<RemoteSettings>), typeof(SettingsView));
            //_mappings.Add(typeof(ExtendedSplashViewModel), typeof(ExtendedSplashView));

            //if (Device.Idiom == TargetIdiom.Desktop)
            //{
            //    _mappings.Add(typeof(HomeViewModel), typeof(UwpHomeView));
            //    _mappings.Add(typeof(SuggestionsViewModel), typeof(UwpSuggestionsView));
            //}
            //else
            //{
            //    _mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            //    _mappings.Add(typeof(SuggestionsViewModel), typeof(SuggestionsView));
            //}
        }

        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : ViewModelBase
        {
            return null;
        }

        public Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase
        {
            return Task.FromResult(true);
        }

        public Task NavigateToWithoutViewModel(Type pageType, object parameter)
        {
            try
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;
                Page page = Activator.CreateInstance(pageType, parameter) as Page;
                navigationPage.PushAsync(page, true);

            }
            catch (Exception e)
            {

            }

            return Task.FromResult(true);
        }
    }
}
