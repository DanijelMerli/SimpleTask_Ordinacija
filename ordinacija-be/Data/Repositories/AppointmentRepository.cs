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
    }
}
