using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Constants.Todo
{
    public static class Todo
    {
        /// <summary>
        /// Beginning of string that 
        /// App Settings are compared against
        /// during startup. Which throws error
        /// if not set. 
        /// </summary>
        public static string TODO = "TODO";
    }
}
