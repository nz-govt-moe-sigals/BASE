using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Constants.Resources.DefaultDocuments
{
    public static class RelativePaths
    {
        public const string DefaultDocuments = "DefaultDocuments";

        public const string TermsAndConditions = DefaultDocuments + "/tandc/" + "tandc.md";
        public const string PrivacyStatement = DefaultDocuments + "/privacy/" + "privacy.md";
        public const string ServiceClientCorrelationStatement = DefaultDocuments + "/serviceclientcorrelation/" + "serviceclientcorrelation.md";
        public const string License = DefaultDocuments + "/license/" + "license.md";

    }
}
