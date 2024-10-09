using Konscious.Security.Cryptography;
using PasswordManager.Helpers;
using PasswordManager.Models;
using PasswordManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class Service
    {
        Repo _repo;
        Hasher _hasher;
       public Service() 
       {
            _repo = new Repo();
            _hasher = new Hasher();
       }

        public void addMasterpassword(string password)
        { 
            var (masterpassword, salt) = _hasher.CreateHash(password);

            var credentials = new Credentials
            {
                Masterpassword = masterpassword,
                salt = salt
            };

            _repo.addMasterPassword(credentials);
        }

        public bool verifyPassword(string password)
        {
            Credentials masterpassword = _repo.getCredentials();
            if (masterpassword == null)
            {
                throw new InvalidOperationException("No Master password is set!");
            }
            return _hasher.VerifyPassword(password, masterpassword.Masterpassword, masterpassword.salt);

        }
    }
}
