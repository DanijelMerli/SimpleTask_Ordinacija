using Microsoft.EntityFrameworkCore;
using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data
{
    public class DataContext : DbContext
    {
        public string DbPath { get; private set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbPath = Environment.CurrentDirectory + "\\dentist.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        private DbSet<Dentist> Dentists { get; set; }
        // problem - weird implementation for single dentist in database
        public Dentist Dentist 
        { 
            get
            {
                // returns last added dentist
                return Dentists.OrderByDescending(d => d.Id).FirstOrDefault();
            }
            set
            {
                Dentists.Add(value);
            }
        }
    }
}
