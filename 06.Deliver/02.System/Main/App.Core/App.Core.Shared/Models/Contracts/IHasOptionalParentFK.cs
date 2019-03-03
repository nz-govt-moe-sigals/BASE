using System;

namespace App.Core.Shared.Models
{
    /// <summary>
    /// 
    /// <para>
    /// See <see cref="IHasRequiredParentFK"/>
    /// </para>
    /// </summary>
    public interface IHasOptionalParentFK {
        Guid? ParentFK { get; set; }
    }


}