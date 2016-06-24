using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Encryption.Test
{
    [TestClass]
    public class TestAES
    {
        [TestMethod]
        public void TestEncrypt()
        {
            //arrange
            IEncryption _Encrptor;
            string expect = "ox6iwZsLsIQyKMu2O1P71g==";
            string actual = "";

            //act
            //_Encrptor = new AES(Encoding.ASCII.GetBytes("d7acbb8bba1a4170b41f91ee48e77786"), Encoding.ASCII.GetBytes("5d4c3c8ad0a047ba"));
            _Encrptor = new AES("d7acbb8bba1a4170b41f91ee48e77786", "5d4c3c8ad0a047ba");
            actual = _Encrptor.EncryptString("ABCDS");

            //assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestDecrypt()
        {
            //arrange
            IEncryption _Encrptor;
            string expect = "ABCDS";
            string actual = "";

            //act
            //_Encrptor = new AES(Encoding.ASCII.GetBytes("d7acbb8bba1a4170b41f91ee48e77786"), Encoding.ASCII.GetBytes("5d4c3c8ad0a047ba"));
            _Encrptor = new AES("d7acbb8bba1a4170b41f91ee48e77786", "5d4c3c8ad0a047ba");
            actual = _Encrptor.DecryptString("ox6iwZsLsIQyKMu2O1P71g==");

            //assert
            Assert.AreEqual(expect, actual);
        }
    }
}
