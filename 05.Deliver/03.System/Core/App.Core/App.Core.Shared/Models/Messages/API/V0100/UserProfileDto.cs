using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string DisplayName { get; set; }
    }
}
