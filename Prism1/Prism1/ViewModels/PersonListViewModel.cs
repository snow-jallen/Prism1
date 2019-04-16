using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism1.Converters;
using Prism1.Models;
using Prism1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prism1.ViewModels
{
    public class PersonListViewModel : ViewModelBase
    {
        public PersonListViewModel(ITimeService timeService,
            MyDataContext dataContext,
            INavigationService navigationService,
            IPageDialogService dialogService)
            :base(navigationService)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    CurrentTime = timeService.GetTime();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });
            this.timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
            this.dataContext = dataContext;
            this.navigationService = navigationService;
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        private string currentTime;
        private readonly ITimeService timeService;
        private readonly MyDataContext dataContext;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public string CurrentTime
        {
            get => currentTime;
            set { SetProperty(ref currentTime, value); }
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return people; }
            set { SetProperty(ref people, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            People = dataContext.People.ToList();
        }

        private DelegateCommand<Person> itemTappedCommand;
        public DelegateCommand<Person> ItemTappedCommand =>
            itemTappedCommand ?? (itemTappedCommand = new DelegateCommand<Person>(ExecuteItemTappedCommand));

        async void ExecuteItemTappedCommand(Person selectedPerson)
        {
            await dialogService.DisplayAlertAsync("Oi!", $"{selectedPerson.FirstName} says 'stop clicking on me!'", "Oh, sorry!");
        }
    }
}
