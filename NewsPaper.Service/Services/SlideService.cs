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
    public class SlideService : ISlideService
    {
        private readonly NewsPaperDbContext _dbContext;

        public SlideService()
        {
            _dbContext = new NewsPaperDbContext();
        }

        public async Task AddAsyn(Slide entity)
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
                var tbl = await GetById(id);
                _dbContext.Entry(tbl).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Slide> GetById(int id)
        {
            try
            {
                return await _dbContext.Slides.FindAsync(id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Slide>> GetListAsyn()
        {
            try
            {
                return await _dbContext.Slides.AsNoTracking().ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<DataTableModel<Slide>> GetPagingList(int length, int page, string search, string oderId, string oderDir)
        {
            try
            {
                DataTableModel<Slide> dataTable = new DataTableModel<Slide>();

                var data = _dbContext.Slides.AsQueryable();
                //Sum of data
                dataTable.TotalRecords = await data.CountAsync();

                //Search data in table slide
                if (!string.IsNullOrEmpty(search))
                {
                    data = data.Where(m => m.Name.ToLower().Contains(search)
                                        || m.Description.ToLower().Contains(search)
                                        || m.Content.ToLower().Contains(search)
                                        || m.Url.ToLower().Contains(search));
                }

                //Oder data in table
                if (!string.IsNullOrEmpty(oderId))
                {
                    switch (oderId)
                    {
                        case "0":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Name) : data.OrderBy(m => m.Name));
                            break;

                        case "1":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Description) : data.OrderBy(m => m.Description));
                            break;

                        case "2":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Content) : data.OrderBy(m => m.Content));
                            break;

                        case "3":
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Url) : data.OrderBy(m => m.Url));
                            break;

                        default:
                            data = (oderDir == "desc" ? data.OrderByDescending(m => m.Id) : data.OrderBy(m => m.Id));
                            break;
                    }
                }
                //Sum of data after the older
                dataTable.FilterRecord = await data.CountAsync();
                //
                dataTable.Data = await data.Skip(page).Take(length).AsNoTracking().ToListAsync();

                return dataTable;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateAsyn(Slide entity)
        {
            try
            {
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