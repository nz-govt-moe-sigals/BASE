using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;

namespace App.Core.Infrastructure.Constants.Tenancy
{
    public class Default
    {
        public static Tenant DefaultTenant = new Tenant
        {
            Id = 1.ToGuid(),
            IsDefault = true /*notice....*/,
            Enabled = true,
            Key = "Default",
            DisplayName = "Default",
            HostName = "Default"
        };
    }
}
