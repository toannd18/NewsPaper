using NewsPaper.Data.Data;
using NewsPaper.Service.ViewModels;
using System.Threading.Tasks;

namespace NewsPaper.Service.Interfaces
{
    public interface INewsCategorieService : IRepository<NewsCategories, int>
    {
        Task<DataTableModel<NewsCategories>> GetPagingList(int length, int page, string search, string oderId, string oderDir);
    }
}