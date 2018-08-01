using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
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

        
        [HttpGet]
        [ActionName("DoesStudentExist")]
        [WebApiAppAuthorize(Roles = "module32_read")]
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
