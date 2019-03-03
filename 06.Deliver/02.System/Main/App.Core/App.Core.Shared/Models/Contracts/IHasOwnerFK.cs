namespace App.Core.Shared.Models
{
    using System;

    public interface IHasOwnerFK
    {
        Guid GetOwnerFk();
    }
}