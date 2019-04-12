using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
            INavigationService navigationService)
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
        }

        private string currentTime;
        private readonly ITimeService timeService;
        private readonly MyDataContext dataContext;
        private readonly INavigationService navigationService;

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

    }
}
