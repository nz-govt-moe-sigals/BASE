namespace App.Core.Infrastructure.Services
{
    public interface IAppHostNamesService
    {

        string[] GetAppHostNamesList();

        string[] GetRoutesList();
    }
}
