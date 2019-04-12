using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Prism1.Models
{
    public class MyDataContext : DbContext
    {
        private static bool created = false;
        public MyDataContext()
        {
            if (!created)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = null;
            string dbName = "flashcards.db";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
                    break;
                case Device.iOS:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbName);
                    SQLitePCL.Batteries_V2.Init();
                    break;
                default:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
                    break;
            }
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        public DbSet<Person> People { get; set; }
    }
}
