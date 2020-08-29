using NewsPaper.Data;
using NewsPaper.Data.Data;
using NewsPaper.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.Service.Services
{
    public class NewsArticleCategorieService : INewsArticleCategorieService
    {
        private readonly NewsPaperDbContext _dbContext;

        public NewsArticleCategorieService()
        {
            _dbContext = new NewsPaperDbContext();
        }

        public async Task Add(List<NewsArticleCategories> newsArticleCategories)
        {
            try
            {
                _dbContext.NewsArticleCategories.AddRange(newsArticleCategories);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteArticaleAsyn(int id)
        {
            try
            {
                var listAritcles = await _dbContext.NewsArticleCategories.Where(x => x.NewsArticleID == id).ToListAsync();
                if (listAritcles != null)
                {
                    _dbContext.NewsArticleCategories.RemoveRange(listAritcles);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteCategorieAsyn(int id)
        {
            try
            {
                var listCategories = await _dbContext.NewsArticleCategories.Where(x => x.NewsCategoryID == id).ToListAsync();
                if (listCategories != null)
                {
                    _dbContext.NewsArticleCategories.RemoveRange(listCategories);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}