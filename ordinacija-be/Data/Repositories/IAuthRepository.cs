using ordinacija_be.DTOs;
using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public interface IAuthRepository
    {
        Dentist Login(DentistLoginDTO code);
    }
}
