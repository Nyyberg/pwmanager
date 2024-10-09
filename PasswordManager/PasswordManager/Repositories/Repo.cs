using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repositories
{
    public class Repo
    {
        RepoContext _context;

        public Repo() 
        { 
            _context = new RepoContext();
            _context.Database.EnsureCreated();
        }

        public void addMasterPassword(Credentials credentials) 
        { 
            _context.Credentials.Add(credentials);
            _context.SaveChanges();
        }

        public Credentials getCredentials()
        {
          return _context.Credentials.FirstOrDefault();
            
        }
    }
}
