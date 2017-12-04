namespace App.Core.Shared.Models
{
    using System;

    public interface IHasPrincipalFK
    {
        Guid PrincipalFK { get; set; }
    }
}