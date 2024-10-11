using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class EncryptedLogins
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
    }
}
