namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller to return System Description (Name/Subtitle/About)
    /// </summary>
    public class SystemInformationController : ODataControllerBase
    {
        public SystemInformationController(IPrincipalService principalService) : base(principalService)
        {
            throw new ToDoException("SystemInformationController");
        }
    }
}