using NewsPaper.Data.Data;
using NewsPaper.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaper.Service.Interfaces
{
    public interface ISlideService:IRepository<Slide,int>
    {
        Task<DataTableModel<Slide>> GetPagingList(int length, int page, string search, string oderId, string oderDir);
    }
}
