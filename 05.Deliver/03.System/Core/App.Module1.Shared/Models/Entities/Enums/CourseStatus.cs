using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module1.Shared.Models.Entities.Enums
{
    public enum CourseStatusType
    {
        Undefined =0,
        Unknown = 1,
        Unspecified = 2,
        Planned = 3,
        Provisioning = 4,
        Enabled = 5,
        Suspending = 6,
        Suspended = 7,
        Cancelling = 8,
        Cancelled = 9
    }

    /// <summary>
    /// Name can't be the same name as the Entity (<see cref="CourseResourceType"/>
    /// </summary>
    public enum CourseResourceEnumType {
        Undefined=0,
        Unknown = 1,
        Unspecified = 2,
        Time = 3,
        Location = 4,
        Subscirption = 5,
        Object = 6,

    }

}
