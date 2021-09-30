using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.DTOs
{
    public class AppointmentCreateDTO
    {
        public DateTime DateAndTime { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
    }
}
