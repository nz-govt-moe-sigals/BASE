namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Globalization;
    using System.Threading;

    public class LocalisationService : ILocalisationService
    {
        public bool ThreadCultureSet { get; private set; }

        public void SetThreadCulture(string clientLocalisationCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(clientLocalisationCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(clientLocalisationCode);
            this.ThreadCultureSet = true;
        }


        public bool IsValidCultureInfoName(string clientLocalisationCode)
        {
            //return
            //    CultureInfo
            //        .GetCultures(CultureTypes.SpecificCultures)
            //        .Any(c => c.Name == clientLocalisationCode);

            //faster: https://stackoverflow.com/a/12375100/8354791
            if (string.IsNullOrWhiteSpace(clientLocalisationCode))
            {
                return false;
            }
            if (clientLocalisationCode == "--")
            {
                return false;
            }
            if (clientLocalisationCode.Length != 2 &&
                (clientLocalisationCode.Length != 5 || clientLocalisationCode[3] != '-'))
            {
                return false;
            }

            try
            {
                var c = new CultureInfo(clientLocalisationCode);
                if (!c.EnglishName.StartsWith("Unknown Language ("))
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
    }
}