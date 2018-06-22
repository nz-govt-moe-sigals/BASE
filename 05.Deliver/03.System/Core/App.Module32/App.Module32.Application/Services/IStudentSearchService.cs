using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Shared.Models.Messages.API.V0100;

namespace App.Module32.Application.Services
{
    public interface IStudentSearchService
    {
        StudentTransportDto FindStudent(StudentTransportSearchDto transportSearch);
    }
}
