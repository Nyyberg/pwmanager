using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Helpers
{
    public class Hasher
    {
        private const int Saltsize = 16;
        private const int Iterations = 2;
        private const int MemorySize = 19 * 1048;
        private const int Parallelism = 1;
        private const int Hashsize = 32;
        

        public byte[] Hashpassword(string password, byte[] salt)
        {
            using (var hasher = new Argon2id(System.Text.Encoding.UTF8.GetBytes(password)))
            {
                hasher.Salt = salt;
                hasher.Iterations = Iterations;
                hasher.MemorySize = MemorySize;
                hasher.DegreeOfParallelism = Parallelism;

                return hasher.GetBytes(Hashsize);
            }
        }

        public (byte[] hash, byte[] salt)CreateHash(string password)
        {
            byte[] salt = new byte[Saltsize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            byte[] hash = Hashpassword(password, salt);
            return (hash, salt);

        }

        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt) 
        { 
            byte[] hash = Hashpassword(password, storedSalt);

            return hash.SequenceEqual(storedHash);
        }
    }
}
