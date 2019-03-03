using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    public class PrincipalLoginDto
    {
        public Guid Id { get; set; }

        public Guid PrincipalFK { get; set; }

        /// <summary>
        /// Can be used to disallow an external IdP login that was previsoulsy trusted.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Credential Name/Login the external IdP uses to distinguish users by (eg: google.com, sts, etc.).
        /// </summary>
        public string IdPLogin { get; set; }

        /// <summary>
        /// The Subject Identifier the external IdP uses to distinguish users by (eg: 'some guid, joeblow', 'joeblow@google.com', etc.).
        /// </summary>
        public string SubLogin { get; set; }

        /// <summary>
        /// Last datetime the user signed in via this login.
        /// </summary>
        public DateTime LastLoggedInUtc { get; set; }
    }
}
