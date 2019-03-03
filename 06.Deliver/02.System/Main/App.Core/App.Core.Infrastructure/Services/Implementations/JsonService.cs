using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    /// Instead of dragging references to Newtonsoft all over your app...
    /// </summary>
    public class JsonService : AppCoreServiceBase, IJsonService
    {
        public T Parse<T>(string input)
        {
            var result = JsonConvert.DeserializeObject<T>(input);
            return result;
        }


        public string Serialize<T>(T model)
        {

            if (model == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(model);

        }
    }
}
