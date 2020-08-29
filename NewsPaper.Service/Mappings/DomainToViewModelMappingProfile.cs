using AutoMapper;
using NewsPaper.Data.Data;
using NewsPaper.Service.ViewModels;
using System.Linq;

namespace NewsPaper.Service.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<NewsArticles, NewsArticleModel>()
                .ForMember(dest => dest.CategoryIds,
                    opt => opt.MapFrom(s => s.NewsArticleCategories.Select(m => m.NewsCategoryID).
                    ToArray()))
               .ForMember(dest => dest.NewsCategories,
                 opt => opt.MapFrom(s => s.NewsArticleCategories.Select(m => new NewsCategories
                 {
                     Id = m.NewsCategoryID,
                     Name = m.NewsCategories.Name
                 }).ToList())); ;

            CreateMap<Slide, SlideViewModel>();
        }
    }
}