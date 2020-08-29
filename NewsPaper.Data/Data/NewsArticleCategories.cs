using NewsPaper.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPaper.Data.Data
{
    public partial class NewsArticleCategories : Auditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NewsArticleID { get; set; }

        [Required]
        public int NewsCategoryID { get; set; }

        [ForeignKey(nameof(NewsArticleID))]
        public NewsArticles NewsArticles { get; set; }

        [ForeignKey(nameof(NewsCategoryID))]
        public NewsCategories NewsCategories { get; set; }
    }
}