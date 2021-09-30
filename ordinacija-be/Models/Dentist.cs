using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Models
{
    public class Dentist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }
        public IEnumerable<AppointmentDuration> Durations { get; set; }
        public byte[] CodeHash { get; set; }
        public byte[] CodeSalt { get; set; }
    }
}
