using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.DTOs
{
    public class AppointmentCreateDTO
    {
        public int Duration { get; set; }
        public string Date { get; set; }
        public long Time { get; set; }
        public string JMBG { get; set; }
        public string Email { get; set; }
    }
}
