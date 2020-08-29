using AutoMapper;
using NewsPaper.Data;
using NewsPaper.Data.Data;
using NewsPaper.Service.AutoMapper;
using NewsPaper.Service.Interfaces;
using NewsPaper.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.Service.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly NewsPaperDbContext _dbContext = new NewsPaperDbContext();
        private readonly NewsArticleCategorieService _newsArticleCategorieService;
        private Mapper _mapper = new Mapper(AutoMapperConfig.RegisterMappings());

        public NewsArticleService()
        {
            _newsArticleCategorieService = new NewsArticleCategorieService();
        }
        public async Task AddAsyn(NewsArticles entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteAsyn(int id)
        {
            try
            {
                var tbl = await _dbContext.NewsArticles.FindAsync(id);
                _dbContext.NewsArticles.Remove(tbl);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<NewsArticles> GetById(int id)
        {
            try
            {
                return await _dbContext.NewsArticles.
                    Where(m => m.Id == id).
                    Include(m => m.NewsArticleCategories.Select(x => x.NewsCategories)).
                    AsNoTracking().
                    SingleOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<NewsArticles>> GetListAsyn()
        {
            try
            {
                return await _dbContext.NewsArticles.AsNoTracking().ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<DataTableModel<NewsArticleModel>> GetPagingList(int length, int page, string search, string oderId, string oderDir)
        {
            try
            {
                DataTableModel<NewsArticleModel> dataTable = new DataTableModel<NewsArticleModel>();
                var data = _dbContext.NewsArticles.AsQueryable();
                dataTable.TotalRecords = await data.CountAsync();

                if (!string.IsNullOrEmpty(search))
                {
                    data = data.Where(m => m.ByLine.ToLower().Contains(search)
                                        || m.PublishDate.ToString("dd/MM/yyyy").Contains(search)
                                        || m.Headline.ToLower().Contains(search)
                                        );
                }

                if (!string.IsNullOrEmpty(oderId))
                {
                    switch (oderId)
                    {
                        case "0":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Headline) : data.OrderBy(m => m.Headline));
                            break;

                        case "1":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.ByLine) : data.OrderBy(m => m.MetaDescription));
                            break;

                        case "2":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.PublishDate) : data.OrderBy(m => m.PublishDate));
                            break;

                        default:
                            data = data.OrderBy(m => m.PublishDate);
                            break;
                    }
                }

                dataTable.FilterRecord = await data.CountAsync();
                var newsArticles = await data.Skip(page).Take(length)
                    .Include(s => s.NewsArticleCategories.Select(n => n.NewsCategories))
                    .ToListAsync();
                dataTable.Data = _mapper.Map<List<NewsArticleModel>>(newsArticles);
                return dataTable;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateAsyn(NewsArticles entity)
        {
            try
            {

                await _newsArticleCategorieService.DeleteArticaleAsyn(entity.Id);
                _dbContext.NewsArticleCategories.AddRange(entity.NewsArticleCategories);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}