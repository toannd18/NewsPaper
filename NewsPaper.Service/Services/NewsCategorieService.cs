using NewsPaper.Data;
using NewsPaper.Data.Data;
using NewsPaper.Service.Interfaces;
using NewsPaper.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.Service.Services
{
    public class NewsCategorieService : INewsCategorieService
    {
        private readonly NewsPaperDbContext _dbContext= new NewsPaperDbContext();

     

        public async Task AddAsyn(NewsCategories entity)
        {
            try
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Added;
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
                var tbl = await _dbContext.NewsCategories.FindAsync(id);
                _dbContext.NewsCategories.Remove(tbl);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<NewsCategories> GetById(int id)
        {
            try
            {
                return await _dbContext.NewsCategories.FindAsync(id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<NewsCategories>> GetListAsyn()
        {
            try
            {
                return await _dbContext.NewsCategories.AsNoTracking().ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<DataTableModel<NewsCategories>> GetPagingList(int length, int page, string search, string oderId, string oderDir)
        {
            try
            {
                DataTableModel<NewsCategories> dataTable = new DataTableModel<NewsCategories>();
                var data = _dbContext.NewsCategories.AsQueryable();
                dataTable.TotalRecords = await data.CountAsync();

                if (!string.IsNullOrEmpty(search))
                {
                    data = data.Where(m => m.Name.ToLower().Contains(search)
                                        || m.MetaDescription.ToLower().Contains(search));
                }

                if (!string.IsNullOrEmpty(oderId))
                {
                    switch (oderId)
                    {
                        case "0":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Name) : data.OrderBy(m => m.Name));
                            break;

                        case "1":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.MetaDescription) : data.OrderBy(m => m.MetaDescription));
                            break;

                        default:
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Id) : data.OrderBy(m => m.Id));
                            break;
                    }
                }

                dataTable.FilterRecord = await data.CountAsync();
                dataTable.Data = await data.Skip(page).Take(length).AsNoTracking().ToListAsync();


                return dataTable;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateAsyn(NewsCategories entity)
        {
            try
            {
                _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}