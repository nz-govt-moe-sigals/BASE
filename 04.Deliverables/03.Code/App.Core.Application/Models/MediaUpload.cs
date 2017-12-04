using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net;
    using App.Core.Shared.Models.Entities;

    public class MediaUpload
    {
        [Required]
        [Display(Name = "Some Data")]
        [StringLength(50, ErrorMessage = "Your misc text cannot be longer than 50 characters.")]
        public string SomeData { get; set; }

        [Required]
        [Display(Name = "Data Classification")]
        public NZDataClassification DataClassification { get; set; }
    }
}