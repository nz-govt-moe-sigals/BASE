using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Module32.Ux.Tests.Models;

namespace App.Module32.Ux.Tests.Utility
{
    public static class ObjectToQueryString
    {
        public static string ToQueryString(this StudentDto dto)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query[nameof(dto.SchoolId)] = dto.SchoolId.ToString();
            query[nameof(dto.DateOfBirth)] = dto.DateOfBirth.ToString("yy-MM-dd");
            query[nameof(dto.FullName)] = dto.FullName.ToString();
            query[nameof(dto.Gender)] = dto.Gender.ToString();
            return "?" + query.ToString();
            //query[nameof(dto.StudentId)] = dto.StudentId.ToString();
        }

        //public string ToQueryString(this SchoolDto dto)
        //{
        //    var query = HttpUtility.ParseQueryString(string.Empty);
        //}
    }
}
