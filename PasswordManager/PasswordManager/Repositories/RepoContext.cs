using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repositories
{
    public class RepoContext : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<EncryptedLogins> EncryptedLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("data source=../../../PasswordDB.db");
        }

    }
}
