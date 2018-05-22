namespace App.Module01.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module22.Shared.Models.Entities;
    using AutoMapper;

    public class ObjectMap_ExampleDto_Example : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<CourseDto, Course>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Timestamp, opt => opt.Ignore())
                .ForMember(t => t.RecordState, opt => opt.Ignore())
                .ForMember(t => t.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.TenantFK, opt => opt.Ignore())
                //
                .ForMember(t => t.DepartmentFK, opt => opt.Ignore())
                .ForMember(t => t.Department, opt => opt.Ignore())
                .ForMember(t => t.Description, opt => opt.Ignore())
                .ForMember(t => t.Enrollments, opt => opt.Ignore())
                .ForMember(t => t.InstructorRoles, opt => opt.Ignore())
                .ForMember(t => t.Key, opt => opt.Ignore())
                .ForMember(t => t.Occurances, opt => opt.Ignore())
                .ForMember(t => t.ResourceAssignments, opt => opt.Ignore())
                .ForMember(t => t.Status, opt => opt.Ignore())
                .ForMember(t => t.StatusFK, opt => opt.Ignore())
                .ForMember(t => t.Title, opt => opt.Ignore())
                ;
        }
    }
}