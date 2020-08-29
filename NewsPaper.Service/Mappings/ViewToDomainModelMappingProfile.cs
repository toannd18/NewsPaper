using AutoMapper;
using NewsPaper.Data.Data;
using NewsPaper.Service.ViewModels;
using System.Linq;

namespace NewsPaper.Service.AutoMapper
{
    public class ViewToDomainModelMappingProfile : Profile
    {
        public ViewToDomainModelMappingProfile()
        {
            CreateMap<NewsCategorieModel, NewsCategories>()
                .ForMember(s => s.UpdatedDate, opt => opt.Ignore())
                .ForMember(s => s.CreatedDate, opt => opt.Ignore())
                .ForMember(s => s.UpdatedBy, opt => opt.Ignore())
                .ForMember(s => s.CreatedBy, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<NewsArticleModel, NewsArticles>()
                .ForMember(dest => dest.NewsArticleCategories,
                opt => opt.MapFrom(s => s.CategoryIds.Select(m => new NewsArticleCategories
                {
                    NewsArticleID = s.Id,
                    NewsCategoryID = m
                }).ToList()));

            CreateMap<SlideViewModel, Slide>();
        }
    }
}