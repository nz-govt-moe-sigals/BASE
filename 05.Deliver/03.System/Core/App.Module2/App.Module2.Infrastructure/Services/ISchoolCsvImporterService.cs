using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Infrastructure.Services
{
    using System.IO;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.Imports;

    public interface ISchoolCsvImporterService
    {
        SchoolDescriptionRaw[] Import(Stream textStream);

        //SchoolDescriptionRaw[] Import(string path);
    }
}
