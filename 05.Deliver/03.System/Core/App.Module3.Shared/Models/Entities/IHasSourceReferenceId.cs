using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Entities
{
    public interface IHasSourceReferenceId
    {
        /// <summary>
        /// The Reference(record) Id that was received from the source 
        /// </summary>
        int SourceReferenceId { get; set; }
    }
}
