using NewsPaper.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaper.Service.Interfaces
{
  public interface INewsArticleCategorieService
    {
        Task DeleteArticaleAsyn(int id);
        Task DeleteCategorieAsyn(int id);

        Task Add(List<NewsArticleCategories> newsArticleCategories);
    }
}
