using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Module32.Application.Services;
using App.Module32.Infrastructure.Services;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
    public class TransportController : ApiControllerCommonBase
    {
        private readonly IExtractServiceController _extractServiceController;
        private readonly IStudentSearchService _studentSearchService;

        public TransportController(IPrincipalService principalService, IExtractServiceController extractServiceController,
            IStudentSearchService studentSearchService) 
            : base(principalService)
        {
            _extractServiceController = extractServiceController;
            _studentSearchService = studentSearchService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("DoesStudentExist")]
        //public StudentTransportDto DoesStudentExist(string SchoolName, string StudentName, DateTime? DateOfBirth)
        public StudentTransportDto DoesStudentExist([FromUri] StudentTransportSearchDto studentTransport)
        {
            //StudentTransportSearchDto studentTransport = new StudentTransportSearchDto()
            //{
            //    DateOfBirth = DateOfBirth,
            //    SchoolId = null,
            //    SchoolName = SchoolName,
            //    StudentName = StudentName
            //};
            return _studentSearchService.FindStudent(studentTransport);
        }


        [AllowAnonymous]
        [HttpGet()]
        [ActionName("Extract")]
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
