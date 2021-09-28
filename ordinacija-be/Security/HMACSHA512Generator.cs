using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Security
{
    public class HMACSHA512Generator : IHashGenerator
    {
        public void GenerateHash(string plaintext, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plaintext));
            }
        }

        public bool VerifyHash(string plaintext, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plaintext));

                if (computedHash.SequenceEqual(hash))
                    return true;
                else
                    return false;
            }
        }
    }
}
