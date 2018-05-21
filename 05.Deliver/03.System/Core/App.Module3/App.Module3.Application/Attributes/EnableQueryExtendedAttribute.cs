
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;
using System.Web.OData.Query;
using Microsoft.OData.UriParser;

namespace App.Module3.Application.Attributes
{
    /// <summary>
    /// used when you take over the ODataQueryExtensions
    /// </summary>
    public class EnableQueryExtendedAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            //SetSkiptoZero(queryOptions);
            //return base.ApplyQuery(queryable, queryOptions);
            var ignoreQueryOptions = AllowedQueryOptions.Skip | AllowedQueryOptions.Top;
            return queryOptions.ApplyTo(queryable, ignoreQueryOptions);
        }

        //turns out i dont even need this
        /// <summary>
        /// WE set the skip to zero because it is double applying the skip
        /// </summary>
        /// <param name="queryOptions"></param>
        private void SetSkiptoZero(ODataQueryOptions queryOptions)
        {
            var skipProperty = queryOptions.GetType().GetProperty("Skip");
            if (skipProperty != null)
            {
                var skipQueryOption = (SkipQueryOption) skipProperty.GetValue(queryOptions);
                if (skipQueryOption != null)
                {
                    var valueProperty = skipQueryOption.GetType().GetField("_value", BindingFlags.Instance | BindingFlags.NonPublic);
                    var rawValueProperty = skipQueryOption.GetType().GetProperty("RawValue");
                    if (valueProperty != null && rawValueProperty != null)
                    {
                        valueProperty.SetValue(skipQueryOption, 0);
                        rawValueProperty.SetValue(skipQueryOption, "0");
                    }
                    //skipProperty.SetValue(queryOptions, skipOption, null);
                }

            }
        }
    }
}
