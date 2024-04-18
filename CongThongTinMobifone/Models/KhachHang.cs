using System.ComponentModel.DataAnnotations;

namespace CongThongTinMobifone.Models
{
    public partial class KhachHang
    {
        [StringLength(10)]
        [Key]
        [Display(Name = "Số điện thoại")]
        public string Number { get; set; }
        [StringLength(50)]
        [Display(Name = "Loại số")]
        public string Number_TypeID { get; set; }
        [StringLength(50)]
        [Display(Name = "Thể loại tin")]
        public string PostCateID { get; set; }
        [StringLength(150)]
        [Display(Name = "mô tả")]
        public string Description { get; set; }
        public string link { get; set; }
    }
}
