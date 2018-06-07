using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Module31.Infrastructure.Services;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    public class TransportController : ApiControllerCommonBase
    {
        private readonly IExtractServiceController _extractServiceController;

        public TransportController(IPrincipalService principalService, IExtractServiceController extractServiceController) 
            : base(principalService)
        {
            _extractServiceController = extractServiceController;
        }

        [AllowAnonymous]
        [HttpPost]
        public StudentDto DoesStudentExist(StudentSearchDto student)
        {
            return new StudentDto();
        }


        [AllowAnonymous]
        [HttpGet]
        public string Extract()
        {
            using (var elapsedTime = new ElapsedTime())
            {
                _extractServiceController.ProcessAllTables();

                return $"success - elapsedTime : {elapsedTime.ElapsedText}";
            }
        }

    }
}
