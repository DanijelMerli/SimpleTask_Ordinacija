using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
        IEnumerable<TimeSpan> GetAvailableHours(TimeSpan duration, DateTime date);
    }
}
