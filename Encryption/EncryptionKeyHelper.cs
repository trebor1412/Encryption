using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class EncryptionKeyHelper
    {
        public static string GenerateAesRandomKey() {
            return Guid.NewGuid().ToString("N");
        }

        public static string GenerateAesRandomInitialVector()
        {
            return Guid.NewGuid().ToString("N").Substring(0,16);
        }
    }
}
