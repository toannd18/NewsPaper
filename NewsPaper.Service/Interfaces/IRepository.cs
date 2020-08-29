using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NewsPaper.Service.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        Task AddAsyn(T entity);
        Task UpdateAsyn(T entity);

        Task DeleteAsyn(K id);

        Task<List<T>> GetListAsyn();

        Task<T> GetById(K id);
    }
}