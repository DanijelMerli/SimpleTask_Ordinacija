using Microsoft.AspNetCore.Mvc;
using ordinacija_be.Data;
using ordinacija_be.DTOs;
using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] AppointmentCreateDTO dto)
        {
            Appointment appointment;

            try
            {
                appointment = new Appointment()
                {
                    DateAndTime = DateTime.Parse(dto.Date).AddTicks(dto.Time),
                    Duration = new AppointmentDuration(dto.Duration),
                    Email = dto.Email,
                    Jmbg = dto.Jmbg
                };
            }
            catch (FormatException fe)
            {
                return BadRequest("Error parsing date: \n" + fe.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            _unitOfWork.AppointmentRepository.AddAppointment(appointment);
            _unitOfWork.SaveChanges();

            return Ok();
        }

        [HttpGet("Hours")]
        public IActionResult GetHours(int duration, string date)
        {
            DateTime dateTime;
            List<TimeSpan> available;

            try
            {
                dateTime = DateTime.Parse(date);
                available = _unitOfWork.AppointmentRepository
                   .GetAvailableHours(new TimeSpan(0, duration, 0), dateTime).ToList();
            }
            catch (FormatException fe)
            {
                return BadRequest("Error parsing date: \n" + fe.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(available);
        }
    }
}
