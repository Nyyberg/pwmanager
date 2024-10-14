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
        public static string Encrypt(string content, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);

                if (aes.Key.Length != 16 && aes.Key.Length != 24 && aes.Key.Length != 32)
                {
                    throw new ArgumentException("Key must be 16, 24, or 32 bytes long.");
                }

                
                aes.GenerateIV();
                byte[] iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv);

                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                       
                        ms.Write(iv, 0, iv.Length);

                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(content);
                            }
                        }

                        
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
            byte[] encryptedDataWithIv = Convert.FromBase64String(encryptedString);

            string decryptedString = string.Empty;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);

                if (aes.Key.Length != 16 && aes.Key.Length != 24 && aes.Key.Length != 32)
                {
                    throw new ArgumentException("Key must be 16, 24, or 32 bytes long.");
                }

               
                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(encryptedDataWithIv, 0, iv, 0, iv.Length);

                
                byte[] encryptedData = new byte[encryptedDataWithIv.Length - iv.Length];
                Array.Copy(encryptedDataWithIv, iv.Length, encryptedData, 0, encryptedData.Length);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv);

                try
                {
                    using (MemoryStream ms = new MemoryStream(encryptedData))
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
                    Console.WriteLine("Decryption failed. Probably due to wrong key or data corruption.");
                }
            }
            return decryptedString;
        }
    }
}


