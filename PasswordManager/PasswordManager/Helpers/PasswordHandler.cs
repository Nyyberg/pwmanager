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
        private static readonly byte[] IV = new byte[16] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF };
        public static string Encrypt(string content, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = IV;

                if (aes.Key.Length != 16 && aes.Key.Length != 24 && aes.Key.Length != 32)
                {
                    throw new ArgumentException("Key must be 16, 24, or 32 bytes long.");
                }

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(content);
                            }
                        }
                        // Read the contents of the MemoryStream before it is disposed
                        string encryptedContent = Convert.ToBase64String(ms.ToArray());
                        return encryptedContent;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Encryption failed with exception: " + ex.Message);
                    return string.Empty;
                }

            }
        }

        public static string Decrypt(byte[] password, string key) 
        {
            string encryptedString = Encoding.UTF8.GetString(password);
            string decryptedString = string.Empty;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = IV;

                if (aes.Key.Length != 16 && aes.Key.Length != 24 && aes.Key.Length != 32)
                {
                    throw new ArgumentException("Key must be 16, 24, or 32 bytes long.");
                }

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] encrypted = Convert.FromBase64String(encryptedString);

                try
                {
                    using (MemoryStream ms = new MemoryStream(encrypted))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                decryptedString = sr.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Decryption failed. Probably due to wrong key.");
                }
            }
             return decryptedString;
        }

    }
}
