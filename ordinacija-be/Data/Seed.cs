using ordinacija_be.Models;
using ordinacija_be.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinacija_be.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDatabase()
        {
            IHashGenerator hashGenerator = new HMACSHA512Generator();
            byte[] hash, salt;
            hashGenerator.GenerateHash("asd", out hash, out salt);

            Dentist dentist = new Dentist()
            {
                Name = "Danijel Merli",
                Email = "danijel.merli@gmail.com",
                CodeHash = hash,
                CodeSalt = salt
            };

            _context.Dentist = dentist;
            _context.SaveChanges();
        }
    }
}
