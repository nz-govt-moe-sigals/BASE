namespace App.Core.Shared.Models.Configuration
{
    using System;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Distributor of the application
    /// (distinct from the Creator) in many commercial cases.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasName" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    public class ApplicationDistributorInformation : IHasName , IHasDescription
    {
        public ApplicationDistributorInformation()
        {
            Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id { get; set; }


        [Alias("App:Core:Application:Provider:Name")]
        public string Name
        {
            get; set;
        }

        [Alias("App:Core:Application:Creator:Description")]
        public string Description
        {
            get; set;
        }

        [Alias("App:Core:Application:Provider:SiteUrl")]
        public string SiteUrl { get; set; }


        [Alias("App:Core:Application:Provider:ContactUrl")]
        public string ContactUrl { get; set; }
    }
}