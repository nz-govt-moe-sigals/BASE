using App.Core.Shared.Factories;
using App.Core.Shared.Models;
using System;
using System.Collections.Generic;

namespace App.Module02.Shared.Models.Messages.API.V0100
{
    public class AccountRoleGroupDto : IHasGuidId
    {
        public AccountRoleGroupDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<AccountRoleGroupDto> Groups { get; set; }

        public ICollection<AccountRoleDto> Roles { get; set; }


    }
}
