using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Helpers
{
    public class PasswordHandler
    {
        public static byte[] Encrypt(string password, byte[] key)
        {
            using (System.Security.Cryptography.Aes MyAes = System.Security.Cryptography.Aes.Create())
            {
                MyAes.KeySize = 256;
                MyAes.Key = key;
                MyAes.GenerateIV();

                var encryptor = MyAes.CreateEncryptor(MyAes.Key, MyAes.IV);

                using (var stream = new MemoryStream()) 
                {
                    stream.Write(MyAes.IV, 0, MyAes.IV.Length);
                    using(var cryptostream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                    using(var streamwrite = new StreamWriter(stream))
                    {
                        streamwrite.Write(password);
                    }
                    return stream.ToArray();
                }
            }
        }

        public static string Decrypt(byte[] password, byte[] key) 
        {
            using(System.Security.Cryptography.Aes MyAes = System.Security.Cryptography.Aes.Create())
            {
                MyAes.Key = key;
                using (var stream = new MemoryStream())
                {
                    byte[] iv = new byte[16];
                    stream.Read(iv, 0, 16);
                    MyAes.IV = iv;
                    var decryptor = MyAes.CreateDecryptor(MyAes.Key, MyAes.IV);
                    var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read);
                    using(var streamRead = new StreamReader(cryptoStream))
                    {
                        return streamRead.ReadToEnd();
                    }

                }
            }
        }

    }
}
