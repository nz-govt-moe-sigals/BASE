namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller to return Creator, Distributor, Vendor information 
    /// </summary>
    public class SystemDeveloperController : ODataControllerBase
    {
        public SystemDeveloperController(IPrincipalService principalService) : base(principalService)
        {
            throw new ToDoException("SystemDeveloperController");
        }
    }
}