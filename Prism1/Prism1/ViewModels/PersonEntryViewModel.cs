using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism1.ViewModels
{
    public class PersonEntryViewModel : ViewModelBase
    {
        public PersonEntryViewModel(INavigationService navigationService, MyDataContext dataContext)
            : base(navigationService)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));

            Person = new Person();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            EntryValue = (string)parameters["entry"];
            var mainPageVM = parameters["blah"] as MainPageViewModel;
            if(mainPageVM != null)
            {
                EntryValue = "www == <= >= ";
            }
        }

        private string entryValue;
        public string EntryValue
        {
            get => entryValue;
            set { SetProperty(ref entryValue, value); }
        }

        private Person person;
        public Person Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }

        private DelegateCommand delegateCommand;
        private readonly MyDataContext dataContext;

        public DelegateCommand SaveCommand =>
            delegateCommand ?? (delegateCommand = new DelegateCommand(ExecuteSaveCommand));

        void ExecuteSaveCommand()
        {
            dataContext.People.Add(Person);
            dataContext.SaveChanges();

            Person = new Person();
        }
    }
}
