using System.Security.Cryptography;
using System.Text;

namespace Application.Security
{
    public static class HashGenerator
    {
        private static string Generate(string plaintext, string hashType)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
            byte[] hashed = HashAlgorithm.Create(hashType).ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }

        public static string Salterhash(this string plaintext)
        {
            return Generate(plaintext, nameof(HashType.MD5)) + Generate(plaintext.Substring(0, plaintext.Length / 2), nameof(HashType.SHA1));
        }
    }
}
