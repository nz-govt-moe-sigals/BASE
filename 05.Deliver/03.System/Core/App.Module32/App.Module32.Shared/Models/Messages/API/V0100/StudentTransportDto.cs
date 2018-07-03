using App.Module32.Shared.Models.Enums;
using Newtonsoft.Json;

namespace App.Module32.Shared.Models.Messages.API.V0100
{
    public class StudentTransportDto
    {

        public StudentTransportDto()
        {
            StudentExist = StudentExistEnum.Enrolled;
        }

        public string Status => StudentExist.ToString();

        [JsonIgnore]
        public StudentExistEnum StudentExist { get; set; }

    }
}
