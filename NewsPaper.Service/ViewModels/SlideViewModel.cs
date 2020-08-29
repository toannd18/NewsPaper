using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewsPaper.Service.ViewModels
{
    public class SlideViewModel
    {
        public SlideViewModel()
        {
        }

        public SlideViewModel(int id, bool status)
        {
            Id = id;
           
            Status = status;
        }

        public int Id { get; set; }

        [DisplayName("Tên")]
        [StringLength(250, ErrorMessage = "Bạn nhập quá dài")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Yêu cầu nhập tên")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(250, ErrorMessage = "Bạn nhập quá dài")]
        public string Description { set; get; }

        [DisplayName("Đường dẫn ảnh")]
        [StringLength(250, ErrorMessage = "Đường dẫn quá dài")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Yêu cầu nhập đường dẫn ảnh")]
        public string Image { set; get; }

        [DisplayName("Đường dẫn liên kết")]
        [StringLength(250, ErrorMessage = "Đường dẫn quá dài")]
        public string Url { set; get; }

        [DisplayName("Vị trí hiển thị")]
        public int? DisplayOrder { set; get; }

        [DisplayName("Tình trạng")]
        public bool Status { set; get; }

        [DisplayName("Nội dung")]
        public string Content { set; get; }

      
    }
}