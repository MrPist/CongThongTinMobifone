using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CongThongTinMobifone.Models
{
    public partial class Phone_number
    {
        [Key]
        [StringLength(50)]
        public string Numnber_MAC { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        [StringLength(50)]
        public string Number_TypeID { get; set; }
        [StringLength(50)]
        public string PostCateID { get; set; }
        [StringLength(150)]
        public int description { get; set; }
        // --- khóa ngoại Number_Type-Phone_number
        [ForeignKey(nameof(Number_TypeID))]
        [InverseProperty(nameof(Number_Type.Phone_number))]
        public virtual Number_Type Number_TypeIDNavigation { get; set; }

        // --- khóa ngoại PostCate-Phone_number
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Phone_number))]
        public virtual Post_cate Phone_numberIDNavigation { get; set; }
    }
}
