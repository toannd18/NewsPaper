using NewsPaper.Data.Common;
using NewsPaper.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPaper.Data.Data
{
    public partial class NewsArticles : Auditable
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Headline { get; set; }

        [Column(TypeName = "text")]
        public string Extract { get; set; }

        [MaxLength(45)]
        public string Encoding { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        [MaxLength(255)]
        public string ByLine { get; set; }

        [MaxLength(255)]
        public string Source { get; set; }

        public StateEnum State { get; set; }

        [MaxLength(255)]
        public string HtmlTitle { get; set; }

        [MaxLength(255)]
        public string HtmlMetaDescription { get; set; }

        [MaxLength(255)]
        public string Tags { get; set; }

        public int Priority { get; set; }

        [Column(TypeName = "text")]
        public string PhotoHtmlAlt { get; set; }

        [MaxLength(256)]
        public string PhotoURL { get; set; }
        public ICollection<NewsArticleCategories> NewsArticleCategories { get; set; }
    }
}