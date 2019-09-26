using System;
using System.Security.Cryptography;

namespace Common.Cryptography
{
    public class SHA1Manager : IDisposable
    {
        private SHA1 sha;

        public SHA1Manager()
        {
            sha = new SHA1CryptoServiceProvider();
        }

        /// <summary>
        /// Returns Base64 string of compued hash
        /// </summary>
        public string ComputeHash(string input)
        {
            return Convert.ToBase64String(sha.ComputeHash(Convert.FromBase64String(input)));
        }

        public void Dispose()
        {
            sha = null;
        }
    }
}