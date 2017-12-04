namespace App.Core.Shared.Models.Messages
{
    using System.Collections.Generic;

    public class ODataResponse<T>
    {
        public List<T> Value { get; set; }
    }
}