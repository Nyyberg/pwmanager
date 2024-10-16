﻿using Konscious.Security.Cryptography;
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

        public byte[] HashChecker(string password)
        {
           return _hasher.Hashpassword(password, new byte[8]);
        }


        public void addLogins(Logins logins, string key) 
        {
            var encryptedlogins = PasswordHandler.Encrypt(logins.Password, key);
            _repo.addLogins(new EncryptedLogins
            {
                Password = Encoding.UTF8.GetBytes(encryptedlogins),
                Username = logins.Username,
                Name = logins.Name,
            });
        }

        public List<Logins> getLogins(string key) 
        {
            List<EncryptedLogins> encryptedList = _repo.getEncryptedLogins();
            List<Logins> decryptedList = new List<Logins>();

            foreach (var items in encryptedList) 
            { 
                var decryptedLogins = PasswordHandler.Decrypt(items.Password, key);
                decryptedList.Add(new Logins
                {
                    Username = items.Username,
                    Name = items.Name,
                    Password = decryptedLogins
                });
            }
            return decryptedList;

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

        public bool checkForMasterpassword()
        {
         Credentials? masterpassword =  _repo.getCredentials();

            if (masterpassword == null) {
                return false;
            }
            return true;

        }
    }
}
