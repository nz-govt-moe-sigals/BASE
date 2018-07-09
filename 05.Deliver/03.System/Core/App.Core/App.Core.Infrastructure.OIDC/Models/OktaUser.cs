using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.IDA.Models
{
    public class OktaUser
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Activated { get; set; }

        public DateTime? StatusChanged { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? PasswordChanged { get; set; }

        public OktaProfile Profile { get; set; }
    }
}
