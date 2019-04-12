using Prism1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prism1.Services
{
    public class DataService
    {
        private MyDataContext dbContext;

        public DataService()
        {
            dbContext = new MyDataContext();
        }

        public void SavePerson(Person p)
        {
            dbContext.People.Add(p);
            dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetPeople()
        {
            return dbContext.People.ToList();
        }
    }
}
