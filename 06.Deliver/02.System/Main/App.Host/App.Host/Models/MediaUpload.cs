using System.ComponentModel.DataAnnotations;
using App.Core.Shared.Models.Entities;

namespace App.Host.Models
{
    public class MediaUpload
    {
        [Required]
        [Display(Name = "Data Classification")]
        public NZDataClassification DataClassification
        {
            get; set;
        }

        [Required]
        [Display(Name = "Some Custom Data")]
        [StringLength(50, ErrorMessage = "Optional text cannot be longer than 50 characters.")]
        public string SomeCustomData { get; set; }

    }
}