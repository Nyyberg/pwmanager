using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        public byte [] Masterpassword { get; set; }
        public byte [] salt { get; set; }
    
    }
}
