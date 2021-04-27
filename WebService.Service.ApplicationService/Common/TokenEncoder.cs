using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Service.ApplicationService.Common
{
    public static class TokenEncoder
    {
        public async static Task<string> Gen()
        {
           
           return $"{RandomString()}w{RandomString()}w{RandomString()}";


        }

        private static string RandomString()
        {
            var pool = "abcdefghjiklm@#$%&HGFTREASDCVNMLP!noqrpstvuxyzapl";
            var Builder = new StringBuilder();
            var random = new Random();
            for (byte i = 0; i < 30; i++)
            {
                Builder.Append(pool.Substring(random.Next(1, pool.Length), 1));
            }

            return Builder.ToString();
        }
    }
}
