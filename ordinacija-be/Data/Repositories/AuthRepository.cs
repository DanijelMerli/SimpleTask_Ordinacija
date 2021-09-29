using ordinacija_be.DTOs;
using ordinacija_be.Models;
using ordinacija_be.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;
        private readonly IHashGenerator _hashGenerator;
        public AuthRepository(DataContext context, IHashGenerator hashGenerator)
        {
            _context = context;
            _hashGenerator = hashGenerator;
        }

        public Dentist Login(DentistLoginDTO dto)
        {
            Dentist dentist = _context.Dentist;

            if(!_hashGenerator.VerifyHash(dto.Code, dentist.CodeHash, dentist.CodeSalt))
            {
                return null;
            }

            return dentist;
        }
    }
}
