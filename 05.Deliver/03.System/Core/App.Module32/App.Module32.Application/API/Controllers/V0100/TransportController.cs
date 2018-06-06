using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    public class TransportController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public StudentDto DoesStudentExist(StudentSearchDto student)
        {
            return new StudentDto();
        }

    }
}
