using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

namespace Backend.Business
{
    public class Cryptography
    {
        public string CriarHash(string txt)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(txt);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder ret = new StringBuilder();
            foreach(byte b in hash)
            {
                ret.Append(b.ToString("X2"));
            }

            return ret.ToString();
        }
    }
}