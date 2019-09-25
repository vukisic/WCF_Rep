using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cryptography
{
    public interface IAesCipher
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
