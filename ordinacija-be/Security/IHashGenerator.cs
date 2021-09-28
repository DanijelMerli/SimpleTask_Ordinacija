using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordinacija_be.Security
{
    public interface IHashGenerator
    {
        void GenerateHash(string plaintext, out byte[] hash, out byte[] salt);
        bool VerifyHash(string plaintext, byte[] hash, byte[] salt);
    }
}
