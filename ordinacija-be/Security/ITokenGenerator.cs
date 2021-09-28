using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Security
{
    public interface ITokenGenerator
    {
        string GenerateTokenString(Dentist dentist);
    }
}
