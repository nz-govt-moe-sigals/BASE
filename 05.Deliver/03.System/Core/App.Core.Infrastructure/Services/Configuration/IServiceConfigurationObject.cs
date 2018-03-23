using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration
{
    /// <summary>
    /// Contract to be applied to all Service Configuration Objects
    /// <para>
    /// </para>
    /// Dependency Injectors work primarily with objects(there are some esoteric exceptions, but generally
    /// most DIs can inject objects into objects into objects -- all based on the Parameter Types of each
    /// classes Constructor -- but get stumped when a constructor argument is a Value type (string, int, etc.)
    /// not knowing where to find the needed string.
    /// </para>
    /// <para>
    /// The common solution is to use Configuration Object that are easiliy discoverable by the
    /// Dependency Injector. We pack them with the strings/ints needed, and the DI happily injects the whole
    /// object/egg into the target service.Done.
    /// </para>
    /// <para>
    /// It also solves other problems.The first being that OO always expected us to work with Objects, so the
    /// code becomes more mature/maintainable (rather than loose bits/pieces flying in close formation),
    /// and secondly, the ConfigurationObject in itself is injectable...so can be injected with other services
    /// (eg: IHostSettingsService) to configure the strings/ints on its own, like a big boy...
    /// </para>
    /// </summary>
    public interface IServiceConfigurationObject
    {

    }
}
