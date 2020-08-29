using System.Collections.Generic;

namespace NewsPaper.Service.ViewModels
{
    public class DataTableModel<T> where T : class
    {
        public List<T> Data { get; set; }

        public int TotalRecords { get; set; }

        public int FilterRecord { get; set; }
    }
}