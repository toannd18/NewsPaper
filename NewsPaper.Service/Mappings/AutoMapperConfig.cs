using AutoMapper;
using NewsPaper.Service.Mappings;

namespace NewsPaper.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewToDomainModelMappingProfile());
                cfg.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}