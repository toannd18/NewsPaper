using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaper.Data.Interfaces
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get ; set ; }
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
        [MaxLength(256)]
        public string MetaKeyword { get; set; }
        [DisplayName("Mô tả")]
        [MaxLength(256, ErrorMessage = "Bạn nhập quá dài")]
      
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}
