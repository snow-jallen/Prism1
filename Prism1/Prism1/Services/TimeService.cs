using System;
using System.Collections.Generic;
using System.Text;

namespace Prism1.Services
{
    public class TimeService : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
