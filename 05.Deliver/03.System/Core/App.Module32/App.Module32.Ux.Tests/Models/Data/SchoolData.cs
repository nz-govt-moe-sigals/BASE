using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module32.Ux.Tests.Models.Data
{
    public static class SchoolData
    {
        static SchoolData()
        {
            SchoolDtosLookup = new Dictionary<int, SchoolDto>();
            SchoolDtosLookup.Add(GetSchoolData_999999().SchoolId, GetSchoolData_999999());
            SchoolDtosLookup.Add(GetSchoolData_999998().SchoolId, GetSchoolData_999998());
            SchoolDtosLookup.Add(GetSchoolData_999997().SchoolId, GetSchoolData_999997());
        }



        public static Dictionary<int, SchoolDto> SchoolDtosLookup { get;  }

        public static SchoolDto GetSchoolData_999999()
        {
            return new SchoolDto() {Name = "Test School 999999", SchoolId = 999999};
        }

        public static SchoolDto GetSchoolData_999998()
        {
            return new SchoolDto() { Name = "Test School 999998", SchoolId = 999998 };
        }

        public static SchoolDto GetSchoolData_999997()
        {
            return new SchoolDto() { Name = "Test School 999997", SchoolId = 999997 };
        }
    }
}
