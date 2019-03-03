using System;

namespace App.Core.Shared.Models
{
    /// <summary>
    /// <para>
    /// See <see cref="IHasOptionalParentFK"/>
    /// </para>
    /// </summary>
    public interface IHasRequiredParentFK
    {
        Guid ParentFK { get; set; }
    }
}