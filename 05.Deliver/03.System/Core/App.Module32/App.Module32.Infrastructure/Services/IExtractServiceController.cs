using System.Threading.Tasks;

namespace App.Module32.Infrastructure.Services
{
    public interface IExtractServiceController
    {
        void ProcessAllTables();
        Task ProcessAllTablesAsync();
    }
}





