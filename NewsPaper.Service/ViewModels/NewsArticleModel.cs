using NewsPaper.Data.Common;
using NewsPaper.Data.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewsPaper.Service.ViewModels
{
    public class NewsArticleModel
    {
        public NewsArticleModel()
        {
            PublishDate = DateTime.Now;
            Id = 0;
        }
        public int Id { get; set; }

        [DisplayName("Tiêu đề")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
        public string Headline { get; set; }

        [DisplayName("Tóm tắt nội dung")]
        public string Extract { get; set; }

        [MaxLength(45)]
        public string Encoding { get; set; }

        [DisplayName("Nội dung bản tin")]
        public string Text { get; set; }

        [DisplayName("Ngày phát hành")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishDate { get; set; }

        [DisplayName("Tác giả bài viết")]
        [MaxLength(255)]
        public string ByLine { get; set; }

        [DisplayName("Nguồn trích dẫn")]
        [MaxLength(255)]
        public string Source { get; set; }

        [DisplayName("Tình trạng")]
        public StateEnum State { get; set; }

        [DisplayName("Tiêu đề Html")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
        public string HtmlTitle { get; set; }

        [DisplayName("Mô tả Html")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
        public string HtmlMetaDescription { get; set; }

        [MaxLength(255)]
        public string Tags { get; set; }

        [DisplayName("Độ ưu tiên")]
        public int Priority { get; set; }

        [DisplayName("Tiêu đề hình ảnh")]
        public string PhotoHtmlAlt { get; set; }

        [DisplayName("Đường dẫn hình ảnh")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
        public string PhotoURL { get; set; }
        [DisplayName("Thể loại")]
        public int[] CategoryIds { get; set; }
        public ICollection<NewsCategories> NewsCategories { get; set; }
        
    }
}