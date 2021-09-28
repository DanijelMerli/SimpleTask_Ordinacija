using Microsoft.AspNetCore.Mvc;
using ordinacija_be.Data;
using ordinacija_be.DTOs;
using ordinacija_be.Models;
using ordinacija_be.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ordinacija_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private ITokenGenerator _tokenGenerator;

        public DentistController(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] DentistLoginDTO dto)
        {
            Dentist dentist = _unitOfWork.AuthRepository.Login(dto);

            if(dentist == null)
            {
                return Unauthorized("Incorrect code");
            }

            string token = _tokenGenerator.GenerateTokenString(dentist);

            return Ok(new { token });
        }
    }
}
