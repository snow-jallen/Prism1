using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Prism1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ICommand goToContentPage;
        private ICommand goToTabbedPage;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        public ICommand GoToTabbedPage => goToTabbedPage ?? (goToTabbedPage = new DelegateCommand(() => NavigationService.NavigateAsync(nameof(PrismTabbedPage))));
        public ICommand GoToContentPage => goToContentPage ?? (goToContentPage = new DelegateCommand(async () =>
        {
            var p = new NavigationParameters();
            p.Add("entry", EntryValue);
            await NavigationService.NavigateAsync(nameof(PrismContentPage1), p);
        }));

        private string entryValue;
        public string EntryValue
        {
            get => entryValue;
            set { SetProperty(ref entryValue, value); }
        }
    }
}
