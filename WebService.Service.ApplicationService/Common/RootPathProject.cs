using WebService.Domain.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebService.Service.ApplicationService.Common
{
    public static class RootPathProject
    {
        public static string Path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    }
}
