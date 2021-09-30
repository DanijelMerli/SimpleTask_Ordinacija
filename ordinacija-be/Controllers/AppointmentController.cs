using Microsoft.AspNetCore.Mvc;
using ordinacija_be.Data;
using ordinacija_be.DTOs;
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
        public IActionResult Create(AppointmentCreateDTO dto)
        {

            return Ok();
        }

        [HttpGet("Hours")]
        public IActionResult GetHours(int duration, string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            List<TimeSpan> available;

            try
            {
                available = _unitOfWork.AppointmentRepository
                   .GetAvailableTimes(new TimeSpan(0, duration, 0), dateTime).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(available);
        }
    }
}
