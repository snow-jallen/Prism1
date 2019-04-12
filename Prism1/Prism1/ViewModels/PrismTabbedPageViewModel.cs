using Prism.Commands;
using Prism.Mvvm;
using Prism1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prism1.ViewModels
{
    public class PrismTabbedPageViewModel : BindableBase
    {
        public PrismTabbedPageViewModel(ITimeService timeService)
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
        }

        private string currentTime;
        private readonly ITimeService timeService;

        public string CurrentTime
        {
            get => currentTime;
            set { SetProperty(ref currentTime, value); }
        }

    }
}
