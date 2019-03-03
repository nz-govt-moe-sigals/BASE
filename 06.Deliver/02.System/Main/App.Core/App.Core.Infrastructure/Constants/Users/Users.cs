using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Constants
{
    public class Users
    {
        public class Anon
        {
            public static Guid Id = 0.ToGuid();
            public static string Name = "Anon";

        }
        public class SysDaemon
        {
            public static Guid Id = 1.ToGuid();
            public static string Name = "SysDaemon";
        }

    }
}
