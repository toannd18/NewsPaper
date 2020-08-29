using NewsPaper.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsPaper.Data.Data
{
    public partial class NewsCategories : Auditable
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public ICollection<NewsArticleCategories> NewsArticleCategories { get; set; }
    }
}