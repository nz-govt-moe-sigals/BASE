using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Application (ie, shows up on the header).
    /// </summary>
    public class ApplicationDescription : IHasName, IHasDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDescription"/> class.
        /// </summary>
        public ApplicationDescription()
        {
            Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the Application
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Alias("App:Core:Application:Name")]
        public string Name { get;set; }

        /// <summary>
        /// Gets or sets the description/byline of the Application.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Alias("App:Core:Application:Description")]
        public string Description { get;set; }
    }
}
