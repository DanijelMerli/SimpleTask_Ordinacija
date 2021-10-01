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
            AppointmentDuration ad = _unitOfWork.AppointmentRepository.GetDurationInstance(dto.Duration);

            if(ad == null)
            {
                return BadRequest("Invalid appointment duration");
            }

            try
            {
                appointment = new Appointment()
                {
                    DateAndTime = DateTime.Parse(dto.Date).AddTicks(dto.Time),
                    Duration = ad,
                    Email = dto.Email,
                    Jmbg = dto.JMBG
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

        [HttpPost("Cancel")]
        public IActionResult CancelAppointment([FromBody] int id)
        {
            try
            {
                _unitOfWork.AppointmentRepository.CancelAppointment(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // even though this method is idempotent, we're using post to avoid sending personal data in url
        [HttpPost("Get")]
        public IActionResult GetAppointment([FromBody] UserDataDTO dto)
        {
            Appointment appointment = _unitOfWork.AppointmentRepository.GetUserAppointment(dto.Email, dto.JMBG);

            if (appointment == null)
            {
                return BadRequest("There are no pending appointments under those credentials");
            }
            else
            {
                return Ok(appointment);
            }
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
