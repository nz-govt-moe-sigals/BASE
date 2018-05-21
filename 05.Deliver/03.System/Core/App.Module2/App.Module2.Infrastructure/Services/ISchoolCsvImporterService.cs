using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module02.Infrastructure.Services
{
    using System.IO;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.Imports;

    public interface ISchoolCsvImporterService
    {
        SchoolDescriptionRaw[] Import(Stream textStream);

        //SchoolDescriptionRaw[] Import(string path);
    }
}
