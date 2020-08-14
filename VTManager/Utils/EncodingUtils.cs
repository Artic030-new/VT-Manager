using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utils
{
    class EncodingUtils
    {
        public static string encode(string s)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(s));
            foreach (byte b in crypto)
                hash.Append(b.ToString("x2"));
            return hash.ToString();
        }
    }
}
