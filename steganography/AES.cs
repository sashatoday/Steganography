using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace steganography {
    class AES {
        private const int keysize = 16; // 128 bytes

        public static string Encrypt(string textData, byte[] key) {
            var textDataBytes = Encoding.UTF8.GetBytes(textData);
            using (var provider = new AesCryptoServiceProvider()) {
                provider.Key = key;
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (var encryptor = provider.CreateEncryptor(provider.Key, provider.IV)) {
                    using (var ms = new MemoryStream()) {
                        ms.Write(provider.IV, 0, keysize);
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
                            cs.Write(textDataBytes, 0, textDataBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        byte[] encryptedDataBytes = ms.ToArray();
                        return Convert.ToBase64String(encryptedDataBytes);
                    }
                }
            }
        }

        public static string Decrypt(string encryptedData, byte[] key) {
            byte[] encryptedDataBytes = Convert.FromBase64String(encryptedData);
            using (var provider = new AesCryptoServiceProvider()) {
                provider.Key = key;
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (var ms = new MemoryStream(encryptedDataBytes)) {
                    byte[] buffer = new byte[keysize];
                    ms.Read(buffer, 0, buffer.Length);
                    provider.IV = buffer;
                    using (var decryptor = provider.CreateDecryptor(provider.Key, provider.IV)) {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
                            byte[] textDataBytes = new byte[encryptedDataBytes.Length];
                            var byteCount = cs.Read(textDataBytes, 0, textDataBytes.Length);
                            return Encoding.UTF8.GetString(textDataBytes, 0, byteCount);
                        }
                    }
                }
            }
        }
    }
}
