using NewsPaper.Data.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewsPaper.Service.ViewModels
{
    public class NewsCategorieModel : Auditable
    {
        public int Id { get; set; }

        [DisplayName("Tên thể loại")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Yêu cầu điền tên thể loại")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
        public string Name { get; set; }

    }
}