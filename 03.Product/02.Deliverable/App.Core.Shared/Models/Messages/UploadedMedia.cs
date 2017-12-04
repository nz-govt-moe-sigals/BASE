using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages
{
    using System.IO;

    // A model to summarize what has been uploaded by an end user.
    // Not persistable (see MediaMetadata).
    public class UploadedMedia
    {
        public long Length { get; set; }
        public byte[] Stream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
