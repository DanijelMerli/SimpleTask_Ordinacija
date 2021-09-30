using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<TimeSpan> GetAvailableTimes(TimeSpan duration, DateTime date);
    }
}
