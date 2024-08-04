using System.Security.Cryptography;
using System.Text;

namespace HumanResource.Api.Helpers;


    public static class HashingHelper
    {
        public static string ComputeMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
