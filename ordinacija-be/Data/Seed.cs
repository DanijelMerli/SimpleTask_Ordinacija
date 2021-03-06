using ordinacija_be.Models;
using ordinacija_be.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinacija_be.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDatabase()
        {
            IHashGenerator hashGenerator = new HMACSHA512Generator();
            byte[] hash, salt;
            hashGenerator.GenerateHash("123", out hash, out salt);

            Dentist dentist = new Dentist()
            {
                Name = "Danijel Merli",
                Email = "danijel.merli@gmail.com",
                ShiftStart = new TimeSpan(9, 0, 0),
                ShiftEnd = new TimeSpan(17, 0, 0),
                Durations = new List<AppointmentDuration>()
                {
                    new AppointmentDuration() { Duration = new TimeSpan(0, 30, 0)},
                    new AppointmentDuration() { Duration = new TimeSpan(0, 60, 0)}
                },
                MinTimeForCancel = new TimeSpan(24, 0, 0),
                CodeHash = hash,
                CodeSalt = salt
            };

            _context.Dentist = dentist;
            _context.SaveChanges();
        }
    }
}
