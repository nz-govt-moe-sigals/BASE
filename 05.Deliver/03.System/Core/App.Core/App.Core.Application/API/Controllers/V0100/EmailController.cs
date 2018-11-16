using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.API.Controllers.V0100
{
    
    public class EmailController : ODataController
    {
        private readonly ISmtpService _smtpService;

        public EmailController(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        public void Post(EmailDto email)
        {
            try
            {
                _smtpService.SendMessage(email.To, email.Subject, email.Body);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
