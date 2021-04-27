using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Common
{
    public static class TokenDecoder
    {
        public static bool DeGen(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 62) return false;
            var Get1 = input.Substring(30, 1);
            var Get2 = input.Substring(61, 1);
            return Get1 == Get2 ? true : false;
        }
    }
}
