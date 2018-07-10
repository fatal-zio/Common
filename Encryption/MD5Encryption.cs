using System.IO;
using System.Security.Cryptography;
using System.Text;
using Common;

namespace MD5Encryption
{
    public class MD5Encryption
    {
        public string Encrypt(string input)
        {
            byte[] resultArray;
            var inputArray = Encoding.Unicode.GetBytes(input);

            using (var algorithm = Aes.Create())
            using (var encryptor = algorithm.CreateEncryptor(GetMD5Hash(Constants.Key), GetMD5Hash(Constants.InitVector)))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(inputArray, 0, inputArray.Length);
                cryptoStream.FlushFinalBlock();
                resultArray = memoryStream.ToArray();
            }

            return Encoding.Unicode.GetString(resultArray);
        }

        public string Decrypt(string input)
        {
            byte[] resultArray;
            var inputArray = Encoding.Unicode.GetBytes(input);

            using (var algorithm = Aes.Create())
            using (var decryptor = algorithm.CreateDecryptor(GetMD5Hash(Constants.Key), GetMD5Hash(Constants.InitVector)))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(inputArray, 0, inputArray.Length);
                cryptoStream.FlushFinalBlock();
                resultArray = memoryStream.ToArray();
            }

            return Encoding.Unicode.GetString(resultArray);
        }

        private static byte[] GetMD5Hash(string input)
        {
            var md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(Encoding.Unicode.GetBytes(input));

            return md5.Hash;
        }
    }
}