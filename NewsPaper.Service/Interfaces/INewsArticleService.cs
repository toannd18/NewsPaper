using NewsPaper.Data.Data;
using NewsPaper.Service.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace NewsPaper.Service.Interfaces
{
    public interface INewsArticleService : IRepository<NewsArticles, int>
    {
        Task<DataTableModel<NewsArticleModel>> GetPagingList(int length, int page, string search, string oderId, string oderDir);
    }
}