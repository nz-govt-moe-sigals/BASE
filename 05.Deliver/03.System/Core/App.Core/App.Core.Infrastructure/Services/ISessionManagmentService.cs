using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services.Implementations;
using App.Core.Shared.Models.Entities;

namespace App.Core.Infrastructure.Services
{
    public interface ISessionManagmentService
    {
        void SaveSessionOperationAsync(SessionOperation sessionOperation, IPrincipalService principalService);
    }
}
