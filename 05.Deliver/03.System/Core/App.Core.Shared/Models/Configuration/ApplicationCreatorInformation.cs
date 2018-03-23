namespace App.Core.Shared.Models.Configuration
{
    using System;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Creator of the application
    /// (distinct from the Distributor/Resellers) in many commercial cases.
    /// <para>
    /// An Immutable Host Settings configuration object
    /// retrieved from the Host Settings.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasName" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    public class ApplicationCreatorInformation : IHasName, IHasDescription
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreatorInformation"/> class.
        /// </summary>
        public ApplicationCreatorInformation()
        {
            Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id
        {
            get; set;
        }

        [Alias("App:Core:Application:Creator:Name")]
        public string Name
        {
            get; set;
        }
        [Alias("App:Core:Application:Creator:Description")]
        public string Description
        {
            get; set;
        }

        [Alias("App:Core:Application:Creator:SiteUrl")]
        public string SiteUrl
        {
            get; set;
        }

        [Alias("App:Core:Application:Creator:ContactUrl")]
        public string ContactUrl
        {
            get; set;
        }
    }
}