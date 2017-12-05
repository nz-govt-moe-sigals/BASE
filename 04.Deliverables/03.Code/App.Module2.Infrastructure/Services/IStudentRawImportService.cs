using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Infrastructure.Services
{
    using System.IO;
    using App.Module2.Infrastructure.Services.Implementations;

    public interface IStudentRawImportService
    {
        void Do(Stream stream);
    }
}
