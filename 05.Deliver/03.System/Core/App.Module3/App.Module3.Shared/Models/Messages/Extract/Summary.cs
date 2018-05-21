using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.Extract
{
    /// <summary>
    /// Table Name : Schools_Directory_API_Summary
    /// </summary>
    public class Summary : BaseMessage
    {
        [JsonProperty("School_Directory_Id")]
        public int SchoolDirectoryId { get; set; }

        [JsonProperty("School_Id")]
        public int SchoolsId { get; set; }

        [JsonProperty("Org_Name")]
        public string OrgName { get; set; }

        [JsonProperty("Org_Type")]
        public string OrgType { get; set; }

        [JsonProperty("Org_Status")]
        public string OrgStatus { get; set; }

        [JsonProperty("Opening_Date")]
        public DateTime? OpeningDate { get; set; }

        [JsonProperty("Closed_Date")]
        public DateTime? ClosedDate { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("Fax")]
        public string Fax { get; set; }

        [JsonProperty("Cohort_Entry_Current")]
        public string CohortEntryCurrent { get; set; }

        [JsonProperty("Cohort_Entry_Future")]
        public string CohortEntryFuture { get; set; }

        [JsonProperty("Cohort_Entry_Future_From")]
        public string CohortEntryFutureFrom { get; set; }

        [JsonProperty("Contact1_Name")]
        public string Contact1Name { get; set; }

        [JsonProperty("Contact1_Role")]
        public string Contact1Role { get; set; }

        [JsonProperty("Contact2_Name")]
        public string Contact2Name { get; set; }

        [JsonProperty("Contact2_Role")]
        public string Contact2Role { get; set; }

        [JsonProperty("Add1_Line1")]
        public string Add1Line1 { get; set; }

        [JsonProperty("Add1_Line2")]
        public string Add1Line2 { get; set; }

        [JsonProperty("Add1_Line3")]
        public string Add1Line3 { get; set; }

        [JsonProperty("Add1_Suburb")]
        public string Add1Suburb { get; set; }

        [JsonProperty("Add1_City")]
        public string Add1City { get; set; }

        [JsonProperty("Add1_Postal_Code")]
        public string Add1PostalCode { get; set; }

        [JsonProperty("Add2_Line1")]
        public string Add2Line1 { get; set; }

        [JsonProperty("Add2_Line2")]
        public string Add2Line2 { get; set; }

        [JsonProperty("Add2_Line3")]
        public string Add2Line3 { get; set; }

        [JsonProperty("Add2_Suburb")]
        public string Add2Suburb { get; set; }

        [JsonProperty("Add2_City")]
        public string Add2City { get; set; }

        [JsonProperty("Add2_Postal_Code")]
        public string Add2PostalCode { get; set; }


        [JsonProperty("WGS_X")]
        public float WgsX { get; set; }

        [JsonProperty("WGS_Y")]
        public float WgsY { get; set; }


        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("Authority_Code")]
        public string AuthorityCode { get; set; }

        [JsonProperty("CoEdStatus_Code")]
        public string CoEdStatusCode { get; set; }

        [JsonProperty("Col_Id")]
        public string ColId { get; set; }

        [JsonProperty("Col_Name")]
        public string ColName { get; set; }

        [JsonProperty("Decile")]
        public int? Decile { get; set; }

        [JsonProperty("Education_Region_Code")]
        public string EducationRegionCode { get; set; }

        [JsonProperty("Local_Office_Id")]
        public string LocalOfficeId { get; set; }

        [JsonProperty("Local_Office_Name")]
        public string LocalOfficeName { get; set; }

        [JsonProperty("School_Classification_Code")]
        public string SchoolClassificationCode { get; set; }

        [JsonProperty("Special_Schooling_Code")]
        public string SpecialSchoolingCode { get; set; }

        [JsonProperty("Teacher_Education_Code")]
        public string TeacherEducationCode { get; set; }

        [JsonProperty("Area_Unit_Code")]
        public string AreaUnitCode { get; set; }

        [JsonProperty("Community_Board_Code")]
        public string CommunityBoardCode { get; set; }

        [JsonProperty("General_Electorate_Code")]
        public string GeneralElectorateCode { get; set; }

        [JsonProperty("Maori_Electorate_Code")]
        public string MaoriElectorateCode { get; set; }

        [JsonProperty("Regional_Council_Code")]
        public string RegionalCouncilCode { get; set; }

        [JsonProperty("Territorial_Authority_Code")]
        public string TerritorialAuthorityCode { get; set; }

        [JsonProperty("Urban_Area_Code")]
        public string UrbanAreaCode { get; set; }

        [JsonProperty("Ward_Code")]
        public string WardCode { get; set; }


        [JsonProperty("Effective_Date")]
        public DateTime? EffectiveDate { get; set; }

        [JsonProperty("International")]
        public int International { get; set; }

        [JsonProperty("European")]
        public int European { get; set; }

        [JsonProperty("Maori")]
        public int Maori { get; set; }

        [JsonProperty("Pasifika")]
        public int Pasifika { get; set; }

        [JsonProperty("Asian")]
        public int Asian { get; set; }

        [JsonProperty("MELAA")]
        public int Melaa { get; set; }

        [JsonProperty("Other")]
        public int Other { get; set; }

        [JsonProperty("SourceDataLastModified_Enrol")]
        public DateTime? SourceDataLastModifiedEnrol { get; set; }

        [JsonProperty("SourceDataLastModified_School_Profiles")]
        public DateTime? SourceDataLastModifiedSchoolProfiles { get; set; }

        [JsonProperty("SourceDataLastModified_WGS")]
        public DateTime? SourceDataLastModifiedWgs { get; set; }
    }
}
