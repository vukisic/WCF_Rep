using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Cryptography
{
    public class AesCipher : IAesCipher, IDisposable
    {
        private readonly string key;
        private readonly string iv;

        public AesCipher()
        {
            this.key = ConfigurationManager.AppSettings["AesKey"];
            this.iv = ConfigurationManager.AppSettings["AesIV"];
        }

        public string Encrypt(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), $"{nameof(input)} is null or empty!");
            string encrypted = "";
            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        encrypted = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }

                return encrypted;
            }
        }

        public string Decrypt(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), $"{nameof(input)} is null or empty!");
            using (Aes aes = Aes.Create())
            {
                var inputArr = Convert.FromBase64String(input);
                aes.Mode = CipherMode.CBC;
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);
                string decrypted = "";
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(inputArr))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return decrypted;
            }
        }

        public void Dispose()
        {
        }
    }
}