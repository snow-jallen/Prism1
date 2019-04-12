using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism1.ViewModels
{
    public class PrismContentPage1ViewModel : ViewModelBase
    {
        public PrismContentPage1ViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            EntryValue = (string)parameters["entry"];
        }

        private string entryValue;
        public string EntryValue
        {
            get => entryValue;
            set { SetProperty(ref entryValue, value); }
        }

    }
}
