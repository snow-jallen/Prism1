using Prism;
using Prism.Ioc;
using Prism1.Models;
using Prism1.Services;
using Prism1.ViewModels;
using Prism1.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prism1
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //Navigation Basics in Prism for Xamarin.Forms
            //https://www.youtube.com/watch?v=33hYzo5cFcE&list=PLG8rj6Rr0BU9fEmM14BbdJ8Ml0GZL06PN&index=2
            await NavigationService.NavigateAsync($"NavigationPage/{nameof(Views.MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PersonListView, PersonListViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage1, PrismContentPage1ViewModel>();

            containerRegistry.RegisterSingleton<ITimeService, TimeService>();
            containerRegistry.RegisterSingleton<MyDataContext>();
        }
    }
}
