using App.Module32.Shared.Models.Enums;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentTransportDto
    {

        public StudentTransportDto()
        {
            StudentExist = StudentExistEnum.TrueButSchoolDiffers;
        }

        public string Result => StudentExist.ToString();

        [JsonIgnore]
        public StudentExistEnum StudentExist { get; set; }

    }
}
