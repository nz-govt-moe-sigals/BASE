using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Infrastructure.Services
{
    using System.IO;
    using App.Module11.Infrastructure.Services.Implementations;

    public interface IStudentRawImportService
    {
        void Do(Stream stream);
    }
}






