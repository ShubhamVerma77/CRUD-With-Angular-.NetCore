using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DummySample.Server.Common
{
    public class EncryptDecrypt
    {
        public static string DecryptStringAES(string cipherText)
        {
            if (cipherText != null)
            {
                var keybytes = Encoding.UTF8.GetBytes("12@fr6g8%jf4&th6");
                var iv = Encoding.UTF8.GetBytes("12@fr6g8%jf4&th6");
                cipherText = cipherText.Replace(" ", "+");
                var encrypted = Convert.FromBase64String(cipherText);
                var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
                return string.Format(decriptedFromJavascript);
            }
            else
            {
                return "";

            }
        }
        public static string EncryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("12@fr6g8%jf4&th6");
            var iv = Encoding.UTF8.GetBytes("12@fr6g8%jf4&th6");

            var decriptedFromJavascript = RequestHash(cipherText, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }
        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }
        public static string RequestHash(string text, byte[] key, byte[] iv)
        {
            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, iv))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var decryptedContent = msEncrypt.ToArray();
                        return Convert.ToBase64String(decryptedContent);
                    }
                }
            }
        }
    }
}
