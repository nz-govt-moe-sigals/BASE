using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Extract
{
    /// <summary>
    /// <seealso cref="App.Module32.Infrastructure.Initialization.ObjectMaps.Extract.Base.ObjectMap_BaseMessage_TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase"/>
    /// </summary>
    public class ObjectMap_StudentProfile_EducationStudentProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<StudentProfile, EducationStudentProfile>()
                    .ForMember(dest => dest.EducationSchoolProfile, opt => opt.Ignore()) //opt.MapFrom(src => src.SchoolId)
                    .ForMember(dest => dest.EducationSchoolProfileFK, opt => opt.Ignore()) //opt.MapFrom(src => src.SchoolId)
                    .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                    .ForMember(dest => dest.FullName, opt => opt.ResolveUsing(src => ResolveFullName(src)))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.NSN, opt => opt.MapFrom(src => src.NSN))
                ;
        }

        private string ResolveFullName(StudentProfile src)
        {
            string middleName = " ";
            if (!string.IsNullOrWhiteSpace(src.MiddleName))
            {
                middleName += src.MiddleName + " ";
            }
            return ((src.FirstName ?? "") + middleName + (src.LastName ?? "")).Trim();
        }
    }
}
