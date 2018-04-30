//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using App.Module3.Shared.Models.Entities;
//using AutoMapper;

//namespace App.Module3.Infrastructure.Services.Mapping
//{
//    public static class ExtractMapping
//    {
//        public static void Map<T>(T source, T dest)
//        where T: class
//        {
//            var type = typeof(T);
//            if (type == typeof(EducationProviderProfile))
//            {
//                MapP(source as EducationProviderProfile, dest as EducationProviderProfile);
//            }
//        }

//        private static void MapP(EducationProviderProfile source, EducationProviderProfile dest)
//        {
//            //Mapper.Map<EducationProviderProfile, EducationProviderProfile>(source, dest); // really want this fixed but until it works
//			dest.Address1City = source.Address1City;
//			dest.Address1Line1 = source.Address1Line1;
//			dest.Address1Line2 = source.Address1Line2;
//			dest.Address1Line3 = source.Address1Line3;
//			dest.Address1PostalCode = source.Address1PostalCode;
//			dest.Address1Suburb = source.Address1Suburb;
//			dest.Address2City = source.Address2City;
//			dest.Address2Line1 = source.Address2Line1;
//			dest.Address2Line2 = source.Address2Line2;
//			dest.Address2Line3 = source.Address2Line3;
//			dest.Address2PostalCode = source.Address2PostalCode;
//			dest.Address2Suburb = source.Address2Suburb;
//			dest.AreaUnitFK = source.AreaUnitFK;
//			dest.AreaUnit = null;
//			dest.AuthorityTypeFK = source.AuthorityTypeFK;
//			dest.AuthorityType = null;
//            /*dest.ClosedDate = source.ClosedDate;
//			dest.SchoolingGenderFK = source.SchoolingGenderFK;
//			dest.SchoolingGender =null;
//			dest.CohortEntryCurrent = source.CohortEntryCurrent;
//			dest.CohortEntryFuture = source.CohortEntryFuture;
//			dest.CohortEntryFutureFrom = source.CohortEntryFutureFrom;
//			dest.CoLFK = source.CoLFK;
//			dest.CoL = null;
//			dest.CommunityBoardFK = source.CommunityBoardFK;
//			dest.CommunityBoard = null;
//			dest.Contact1Name = source.Contact1Name;
//			dest.Contact1Role = source.Contact1Role;
//			dest.Contact2Name = source.Contact2Name;
//			dest.Contact2Role = source.Contact2Role;
//			dest.Decile = source.Decile;
//			dest.RegionFK = source.RegionFK;
//			dest.Region = null;
//			dest.Email = source.Email;
//			dest.Fax = source.Fax;
//			dest.GeneralElectorateFK = source.GeneralElectorateFK;
//			dest.GeneralElectorate = null;
//			dest.LocalOfficeFK = source.LocalOfficeFK;
//			dest.LocalOffice = null;
//			dest.MaoriElectorateFK = source.MaoriElectorateFK;
//			dest.MaoriElectorate =null;
//			dest.OpeningDate = source.OpeningDate;
//			dest.Name = source.Name;
//			dest.StatusFK = source.StatusFK;
//			dest.Status = null;
//			dest.ClassificationFK = source.ClassificationFK;
//			dest.Classification = null;
//			dest.RegionalCouncilFK = source.RegionalCouncilFK;
//			dest.RegionalCouncil = null;
//			dest.EducationProviderTypeFK  = source.EducationProviderTypeFK;
//			dest.EducationProviderType= null;
//			dest.SchoolId = source.SchoolId;
//			dest.SpecialSchoolingFK = source.SpecialSchoolingFK;
//			dest.SpecialSchooling = null;
//			dest.TeacherEducationFK = source.TeacherEducationFK;
//			dest.TeacherEducation = null;
//			dest.Telephone = source.Telephone;
//			dest.TerritorialAuthorityFK = source.TerritorialAuthorityFK;
//			dest.TerritorialAuthority = null;
//			dest.UrbanAreaFK = source.UrbanAreaFK;
//			dest.UrbanArea = null;
//			dest.Url = source.Url;
//			dest.WardFK = source.WardFK;
//			dest.Ward = null;*/
//        }

//    }
//}
