using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;
using System.Web.OData.Query;

namespace App.Module3.Application.ExtensionMethods
{
    public class ODataQueryOptionsTest<T> : ODataQueryOptions<T>
    {
        public ODataQueryOptionsTest(ODataQueryContext context, HttpRequestMessage request) : base(context, request)
        {
        }

    }
}
