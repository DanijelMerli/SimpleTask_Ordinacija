using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
    }
}
