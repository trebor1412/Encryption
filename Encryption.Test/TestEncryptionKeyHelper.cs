using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encryption.Test
{
    [TestClass]
    public class TestEncryptionKeyHelper
    {        
        [TestMethod]
        public void TestGenerateAesRandomKey()
        {
            //arrange
            bool expect = true;
            bool actual = true;
            string key = "";

            //act
            key = EncryptionKeyHelper.GenerateAesRandomKey();
            actual = (key != "" && key.Length==32);

            //assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestGenerateAesRandomInitialVector()
        {
            //arrange
            bool expect = true;
            bool actual = true;
            string key = "";

            //act
            key = EncryptionKeyHelper.GenerateAesRandomInitialVector();
            actual = (key != "" && key.Length == 16);

            //assert
            Assert.AreEqual(expect, actual);
        }
    }
}
