using Microsoft.AspNetCore.Mvc;
using ordinacija_be.Data;
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
    }
}
