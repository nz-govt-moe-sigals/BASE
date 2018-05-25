namespace App.Module22.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module22.Shared.Models.Entities;
    using AutoMapper;

namespace App.Module22.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    public class ObjectMap_Course_CourseDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Course, CourseDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.PublicText, opt => opt.Ignore())
                .ForMember(t => t.SensitiveText, opt => opt.Ignore())
                //Note how PrivateText and Owner Id never leave the app via an API...
                ;
        }
    }
}