using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Module32.Infrastructure.Services;
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
        public async Task<string> ExtractAsync()
        {
            using (var elapsedTime = new ElapsedTime())
            {
                await _extractServiceController.ProcessAllTablesAsync();

                return $"success - elapsedTime : {elapsedTime.ElapsedText}";
            }
        }

    }
}
