namespace App.Core.Shared.Models.Entities
{
    using System;

    public class PrincipalSetting : SettingBase
    {
        // Id of the Principal/User who this Setting is for.
        public virtual Guid UserFK { get; set; }
    }
}