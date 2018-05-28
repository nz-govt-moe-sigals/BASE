﻿using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class GeolocationService : AppCoreServiceBase, IGeolocationService
    {
        GeolocationServiceConfiguration _geolocationServiceConfiguration;

        public GeolocationService(GeolocationServiceConfiguration geolocationServiceConfiguration)
        {
            _geolocationServiceConfiguration = geolocationServiceConfiguration;
        }

        public GeoCoordinates Get(string ip)
        {
            throw new ToDoException("Need a service!");
        }



    }
}
