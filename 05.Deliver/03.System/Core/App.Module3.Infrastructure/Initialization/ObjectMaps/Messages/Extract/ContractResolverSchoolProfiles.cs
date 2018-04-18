using App.Module3.Shared.Models.Messages.Extract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public class ContractResolverSchoolProfiles : BaseMessageContractResolver<SchoolProfiles>
    {
        public ContractResolverSchoolProfiles() : base()
        {
            AddMap(x => x.ProfilesId, "Profiles_Id");
            AddMap(x => x.SchoolsId, "School_Id");
            AddMap(x => x.OrgName, "Org_Name");
            AddMap(x => x.OrgType, "Org_Type");
            AddMap(x => x.OrgStatus, "Org_Status");
            AddMap(x => x.OpeningDate, "Opening_Date");
            AddMap(x => x.ClosedDate, "Closed_Date");
            AddMap(x => x.Email, "Email");
            AddMap(x => x.Telephone, "Telephone");
            AddMap(x => x.Fax, "Fax");
            AddMap(x => x.CohortEntryCurrent, "Cohort_Entry_Current");
            AddMap(x => x.CohortEntryFuture, "Cohort_Entry_Future");
            AddMap(x => x.CohortEntryFutureFrom, "Cohort_Entry_Future_From");
            AddMap(x => x.Contact1Name, "Contact1_Name");
            AddMap(x => x.Contact1Role, "Contact1_Role");
            AddMap(x => x.Contact2Name, "Contact2_Name");
            AddMap(x => x.Contact2Role, "Contact2_Role");
            AddMap(x => x.Add1Line1, "Add1_Line1");
            AddMap(x => x.Add1Line2, "Add1_Line2");
            AddMap(x => x.Add1Line3, "Add1_Line3");
            AddMap(x => x.Add1Suburb, "Add1_Suburb");
            AddMap(x => x.Add1City, "Add1_City");
            AddMap(x => x.Add1PostalCode, "Add1_Postal_Code");
            AddMap(x => x.Add2Line1, "Add2_Line1");
            AddMap(x => x.Add2Line2, "Add2_Line2");
            AddMap(x => x.Add2Line3, "Add2_Line3");
            AddMap(x => x.Add2Suburb, "Add2_Suburb");
            AddMap(x => x.Add2City, "Add2_City");
            AddMap(x => x.Add2PostalCode, "Add2_Postal_Code");
            AddMap(x => x.Url, "URL");
            AddMap(x => x.AuthorityCode, "Authority_Code");
            AddMap(x => x.CoEdStatusCode, "CoEdStatus_Code");
            AddMap(x => x.ColId, "Col_Id");
            AddMap(x => x.ColName, "Col_Name");
            AddMap(x => x.Decile, "Decile");
            AddMap(x => x.EducationRegionCode, "Education_Region_Code");
            AddMap(x => x.LocalOfficeId, "Local_Office_Id");
            AddMap(x => x.LocalOfficeName, "Local_Office_Name");
            AddMap(x => x.SchoolClassificationCode, "School_Classification_Code");
            AddMap(x => x.SpecialSchoolingCode, "Special_Schooling_Code");
            AddMap(x => x.TeacherEducationCode, "Teacher_Education_Code");
            AddMap(x => x.AreaUnitCode, "Area_Unit_Code");
            AddMap(x => x.CommunityBoardCode, "Community_Board_Code");
            AddMap(x => x.GeneralElectorateCode, "General_Electorate_Code");
            AddMap(x => x.MaoriElectorateCode, "Maori_Electorate_Code");
            AddMap(x => x.RegionalCouncilCode, "Regional_Council_Code");
            AddMap(x => x.TerritorialAuthorityCode, "Territorial_Authority_Code");
            AddMap(x => x.UrbanAreaCode, "Urban_Area_Code");
            AddMap(x => x.WardCode, "Ward_Code");
        }



    }
}
