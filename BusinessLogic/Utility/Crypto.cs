using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System;
namespace MYFAN.BusinessLogic
{
    public class Crypto
    {
        private const int SALT_VALUE_SIZE_IN_BYTES = 16;

        // '' <summary>
        // ''     SHA512 Hashing will be used for storing passwords.  A new Salt should be generated for each and every password.  The Hashed
        // ''     password and Salt will be stored in the DB. 
        // '' </summary>
        // '' <returns>Return a Base64 string representation of the random number</returns>
        // '' <remarks>Generate a cryptographic random number using the cryptographic service provider</remarks>
        public String GenerateSaltValue()
        {
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            byte[] buff = new byte[SALT_VALUE_SIZE_IN_BYTES];
            rand.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public byte[] HashPassword(string clearPassword, string salt)
        {
            string saltedPassword = string.Concat(salt, clearPassword);
            //  Set Hash Algorithm
            SHA512CryptoServiceProvider hashAlg = new SHA512CryptoServiceProvider();
            //  Create Byte Password and Hashed Byte Password using hash algorythm
            byte[] bytePassword = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            byte[] byteHashPassword = hashAlg.ComputeHash(bytePassword);
            return byteHashPassword;
        }

        private const int AES_KEY_SIZE_BITS = 256;
        private const int AES_BLOCK_SIZE_BITS = 128;
        protected byte[] AES_KEY { get; set; }
        protected byte[] AES_IV { get; set; }



        //  EncryptString

        public string EncryptString(string ClearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
            AesCryptoServiceProvider myAes = new AesCryptoServiceProvider();
            myAes.KeySize = AES_KEY_SIZE_BITS;
            myAes.BlockSize = AES_BLOCK_SIZE_BITS;
            if (((this.AES_KEY == null)
                        || (this.AES_IV == null)))
            {
                GenerateEncryptionKeyIV("MyFan");
            }
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, myAes.CreateEncryptor(this.AES_KEY, this.AES_IV), CryptoStreamMode.Write);
            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        //  DecryptString
        public string DecryptString(string EncryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);
            AesCryptoServiceProvider myAes = new AesCryptoServiceProvider();
            myAes.KeySize = AES_KEY_SIZE_BITS;
            myAes.BlockSize = AES_BLOCK_SIZE_BITS;
            if (((this.AES_KEY == null)
                        || (this.AES_IV == null)))
            {
                GenerateEncryptionKeyIV("MyFan");
            }
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, myAes.CreateDecryptor(this.AES_KEY, this.AES_IV), CryptoStreamMode.Write);
            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }


        protected void GenerateEncryptionKeyIV(string PassPhrase)
        {
            Rfc2898DeriveBytes KeyGen;
            byte[] Salt = { 37, 8, 157, 19, 216, 94, 50, 48 };
            KeyGen = new Rfc2898DeriveBytes(PassPhrase, Salt, 1059);
            AesCryptoServiceProvider myAes = new AesCryptoServiceProvider();
            myAes.KeySize = AES_KEY_SIZE_BITS;
            myAes.BlockSize = AES_BLOCK_SIZE_BITS;
            this.AES_KEY = KeyGen.GetBytes((myAes.KeySize / 8));
            this.AES_IV = KeyGen.GetBytes((myAes.BlockSize / 8));
        }

    }
}