﻿using System.Security.Cryptography;
using System.Text;

namespace webapi.Services
{
    public class Password
    {
        public static string Hash(string pass)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            string hashedValue = builder.ToString();
            return hashedValue;
        }
    }
}
