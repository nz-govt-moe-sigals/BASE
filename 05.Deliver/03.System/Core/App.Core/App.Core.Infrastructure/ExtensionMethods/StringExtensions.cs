using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class StringExtensions
    {
        public static byte[] GetHashAsByteArray(this string media, string algorithm = "SHA-256")
        {
            using (var ha = HashAlgorithm.Create(algorithm))
            {
                var hash = ha.ComputeHash(Encoding.UTF8.GetBytes(media));
                return hash;
            }

        }
        public static string GetHashAsString(this string media, string algorithm = "SHA-256")
        {
            var hash = media.GetHashAsByteArray(algorithm);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
