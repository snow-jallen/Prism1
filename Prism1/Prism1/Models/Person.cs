using System;
using System.Collections.Generic;
using System.Text;

namespace Prism1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string FavoriteFood { get; set; }
        public int Age => (int)((DateTime.Today - (Birthday ?? DateTime.Today)).TotalDays / 365);//yes, it's wrong - deal with it.
    }
}
