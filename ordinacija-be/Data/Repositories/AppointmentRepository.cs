using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DataContext _context;
        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }

        // checks for taken appointments on selected day and returns free ones for selected duration
        public IEnumerable<TimeSpan> GetAvailableTimes(TimeSpan duration, DateTime date)
        {
            Dentist d = _context.Dentist;
            if (!_context.Dentist.Durations.Any(a => a.Duration == duration))
            {
                throw new Exception("Invalid appointment duration");
            }

            List<Appointment> taken = _context.Appointments
                .Where(a => a.DateAndTime.Date.Equals(date.Date))
                .ToList();

            TimeSpan current = _context.Dentist.ShiftStart;

            if (date.Date.Equals(DateTime.Today))
            {
                while (current < DateTime.Now.TimeOfDay)
                {
                    current += duration;
                }
            }

            List<TimeSpan> result = new List<TimeSpan>();

            while (current < _context.Dentist.ShiftEnd)
            {
                if(!taken.Any(a => IsIntervening(a.DateAndTime.Date.TimeOfDay, a.Duration.Duration, current, duration)))
                {
                    result.Add(new TimeSpan(current.Ticks));
                }

                current += duration;
            }

            return result;
        }

        private bool IsIntervening(TimeSpan t1, TimeSpan d1, TimeSpan t2, TimeSpan d2)
        {
            return t1 < t2.Add(d2) && t1.Add(d1) > t2;
        }
    }
}
