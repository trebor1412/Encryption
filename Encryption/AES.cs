using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    public class AES : IEncryption
    {
        private AesCryptoServiceProvider _cryptoServiceProvider;

        private AesCryptoServiceProvider cryptoServiceProvider
        {
            get
            {
                return this._cryptoServiceProvider;
            }
            set
            {
                this._cryptoServiceProvider = value;
            }
        }

        public AES(byte[] key, byte[] iv)
        {
            try
            {
                this.cryptoServiceProvider = new AesCryptoServiceProvider
                {
                    Key = key,
                    IV = iv
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AES(string key, string iv) {
            try
            {
                this.cryptoServiceProvider = new AesCryptoServiceProvider
                {
                    Key = Encoding.ASCII.GetBytes(key),
                    IV = Encoding.ASCII.GetBytes(iv)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AES(byte[] key, byte[] iv, byte[] salt)
        {
            this.cryptoServiceProvider = new AesCryptoServiceProvider
            {
                Key = new Rfc2898DeriveBytes(key, salt, 8).GetBytes(32),
                IV = new Rfc2898DeriveBytes(iv, salt, 8).GetBytes(16)
            };
        }

        public string DecryptString(string encryptedSource)
        {
            byte[] encryptedSourceData = Convert.FromBase64String(encryptedSource);
            MemoryStream memoryStream = new MemoryStream();
            string DecryptString;
            try
            {
                CryptoStream cryptoStream = new CryptoStream(memoryStream, this.cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
                try
                {
                    cryptoStream.Write(encryptedSourceData, 0, encryptedSourceData.Length);
                    cryptoStream.FlushFinalBlock();
                    DecryptString = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
                finally
                {
                    bool flag = cryptoStream != null;
                    if (flag)
                    {
                        ((IDisposable)cryptoStream).Dispose();
                    }
                }
            }
            finally
            {
                bool flag = memoryStream != null;
                if (flag)
                {
                    ((IDisposable)memoryStream).Dispose();
                }
            }
            return DecryptString;
        }

        public string EncryptString(string source)
        {
            byte[] sourceData = Encoding.UTF8.GetBytes(source);
            MemoryStream memoryStream = new MemoryStream();
            string EncryptString;
            try
            {
                CryptoStream cryptoStream = new CryptoStream(memoryStream, this.cryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
                try
                {
                    cryptoStream.Write(sourceData, 0, sourceData.Length);
                    cryptoStream.FlushFinalBlock();
                    EncryptString = Convert.ToBase64String(memoryStream.ToArray());
                }
                finally
                {
                    bool flag = cryptoStream != null;
                    if (flag)
                    {
                        ((IDisposable)cryptoStream).Dispose();
                    }
                }
            }
            finally
            {
                bool flag = memoryStream != null;
                if (flag)
                {
                    ((IDisposable)memoryStream).Dispose();
                }
            }
            return EncryptString;
        }
    }
}
