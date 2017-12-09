using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Infrastructure.Services
{
    using App.Module2.Infrastructure.Services.Implementations;

    public interface INameParsingService
    {
        NameParts Parse(string fullName, bool singleNameIsLastName=false);
    }
}
