using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Enums;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentDto
    {

        public StudentDto()
        {
            StudentExist = StudentExistEnum.Unknown;
        }

        public string Result => StudentExist.ToString();

        [JsonIgnore]
        public StudentExistEnum StudentExist { get; set; }

    }
}
