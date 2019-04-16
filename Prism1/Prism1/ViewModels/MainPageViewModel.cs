using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public ICommand GoToTabbedPage => goToTabbedPage ?? (goToTabbedPage = new DelegateCommand(async () =>
        {
            var result = await dialogService.DisplayActionSheetAsync("Action Sheet Title", "Don't do it!", "DESTROY!!!", "Other Option #3", "Other Option #4", "Really crazy long Option #5\nwith Multiple Lines");
            if (result == "Don't do it!")
            {
                await dialogService.DisplayActionSheetAsync("Using custom action buttons",
                    ActionSheetButton.CreateCancelButton("Run Away!", () => EntryValue = "Run AWAY!!!"),
                    ActionSheetButton.CreateDestroyButton("Do you feel lucky?", () => EntryValue = "Well do you?"),
                    ActionSheetButton.CreateButton("3rd Alternative", () => EntryValue = "You don't actually think you have a choice do you?"));
            }

            await NavigationService.NavigateAsync(nameof(PersonListView));
        }));

        public ICommand GoToContentPage => goToContentPage ?? (goToContentPage = new DelegateCommand(async () =>
        {
            var result = await dialogService.DisplayAlertAsync("Alert Title", "Alert Message", "Okey Dokey", "Negatory");

            if (!result)
                return;

            var p = new NavigationParameters();
            p.Add("entry", EntryValue);
            await NavigationService.NavigateAsync(nameof(PersonEntryView), p);
        }));

        private string entryValue;
        private readonly IPageDialogService dialogService;

        public string EntryValue
        {
            get => entryValue;
            set { SetProperty(ref entryValue, value); }
        }
    }
}
