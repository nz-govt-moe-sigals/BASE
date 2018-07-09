using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.IDA.Models;

namespace App.Core.Infrastructure.IDA.Services
{
    public interface IOktaUserService
    {
        IList<OktaUser> GetUserOktaUsers();
    }
}
