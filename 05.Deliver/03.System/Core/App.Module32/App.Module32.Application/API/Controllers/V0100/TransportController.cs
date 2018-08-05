using System;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using App.Core.Infrastructure.Services;
using App.Module32.Application.API.Controllers.Base;
using App.Module32.Application.Services;
using App.Module32.Infrastructure.Services;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.API.Controllers.V0100
{
   
    public class TransportController : ApiModuleControllerBase
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

        
        [HttpGet]
        [ActionName("DoesStudentExist")]
        //public StudentTransportDto DoesStudentExist(string SchoolName, string StudentName, DateTime? DateOfBirth)
        public StudentTransportDto DoesStudentExist([FromUri] StudentTransportSearchDto studentTransport)
        {
            return _studentSearchService.FindStudent(studentTransport);
        }


        [HttpGet()]
        [ActionName("Extract")]
        public IHttpActionResult Extract()
        {
            // also see StudentProfilesExtractService for what to do with Students with no schools
            throw new NotImplementedException();
            using (var elapsedTime = new ElapsedTime())
            {
                //_extractServiceController.ProcessAllTables();
                HostingEnvironment.QueueBackgroundWorkItem(item =>
                    _extractServiceController.ProcessAllTables()
                    );
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, $"success - elapsedTime : {elapsedTime.ElapsedText}"));
            }
        }

    }
}
