using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public interface IAppointmentRepository
    {
        Appointment GetUserAppointment(string email, string jmbg);
        void AddAppointment(Appointment appointment);
        IEnumerable<TimeSpan> GetAvailableHours(TimeSpan duration, DateTime date);
        AppointmentDuration GetDurationInstance(int duration);
        void CancelAppointment(int id);
    }
}
