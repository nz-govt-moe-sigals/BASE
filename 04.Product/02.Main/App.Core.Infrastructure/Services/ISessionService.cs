using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;

    public interface ISessionService
    {
        Session CreateSession(Principal principal);
    }
}
