using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.Common
{
    public static class GuidFakeExtension
    {
            public static Guid Fake(this Guid guid, byte Id)
            {

                return Guid.Parse($"{Id}0000000-0000-0000-0000-000000000000");
            }

    }
}
