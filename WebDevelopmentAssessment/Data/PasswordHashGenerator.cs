using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Data
{
    public class PasswordHashGenerator 
    {
        // yes, i did make an unsalted password hash generator. no, it doesn't do anything useful.
        public static string GenerateHash(string password)
        {
            HashAlgorithm hashgen = SHA256.Create();
            byte[] hbytes = hashgen.ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Join(string.Empty, hbytes.Select(hbytes => hbytes));
        }
    }
}
