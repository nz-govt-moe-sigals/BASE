using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Instead of dragging references to Newtonsoft all over your app...
    /// </summary>
    public interface IJsonService
    {

        T Parse<T>(string input);

        string Serialize<T>(T model);
    }
}
