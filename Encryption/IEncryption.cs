using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public interface IEncryption
    {
        string EncryptString(string source);

        string DecryptString(string encryptedSource);
    }
}
