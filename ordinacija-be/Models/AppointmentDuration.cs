using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Models
{
    public class AppointmentDuration
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
