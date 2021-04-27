using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Common.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string Command,Exception ex) : base($"Erorr {ex.Source} : {ex.Data} - {ex.Message}")
        {

        }
    }
}
