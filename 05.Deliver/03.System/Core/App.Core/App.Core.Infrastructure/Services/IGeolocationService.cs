using App.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services
{
    public interface IGeolocationService
    {

        GeoCoordinates Get(string ip);

    }
}
