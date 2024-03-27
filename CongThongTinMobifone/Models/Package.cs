using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongThongTinMobifone.Models
{
    public partial class Package
    {
        [Key]
        [StringLength(50)]
        public string Package_ID { get; set; }
        [StringLength(100)]
        public string Package_title { get; set; }
        [StringLength(20)]
        public string Package_Cate { get; set; }
        public string Package_content { get; set; }
        [StringLength(150)]
        public string description { get; set; }
        [StringLength(50)]
        public string PostCateID { get; set; }
        // --- khóa ngoại PostCate-Package
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Package))]
        public virtual Post_cate PackageIDNavigation { get; set; }
    }
}
