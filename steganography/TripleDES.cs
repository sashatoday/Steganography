using System;
using System.Security.Cryptography;
using System.Text;

namespace steganography {
    class TripleDES {

        public static string Encrypt(string textData, byte[] key) {
            byte[] textDataBytes = UTF8Encoding.UTF8.GetBytes(textData);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            key = hashmd5.ComputeHash(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = key;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] encryptedDataBytes = cTransform.TransformFinalBlock(textDataBytes, 0, textDataBytes.Length);
            tdes.Clear();
            return Convert.ToBase64String(encryptedDataBytes, 0, encryptedDataBytes.Length);
        }

        public static string Decrypt(string encryptedData, byte[] key) {
            byte[] encryptedDataBytes = Convert.FromBase64String(encryptedData);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            key = hashmd5.ComputeHash(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = key;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] textDataBytes = cTransform.TransformFinalBlock(encryptedDataBytes, 0, encryptedDataBytes.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(textDataBytes);
        }
    }
}
