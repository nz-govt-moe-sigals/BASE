namespace App.Core.Infrastructure.Initialization.ObjectMaps
{
    using AutoMapper;

    /// <summary>
    ///     Contract implemented by AutoMapper configuration elements.
    /// </summary>
    public interface IHasAutomapperInitializer : IHasInitializer
    {
        void Initialize(IMapperConfigurationExpression config);
        /*
         * An example might be:  
            public class ObjectMap_Example_ExampleDto : IHasAutomapperInitializer    {
                public static void Initialize(IMapperConfigurationExpression config) {
                    config.CreateMap<Example, ExampleDto>()
                        .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                        ;
                }
            }
         */
    }
}