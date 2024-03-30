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
        public string Package_CateID { get; set; }
        public string Package_content { get; set; }
        [StringLength(50)]
        public string PostCateID { get; set; }
        [StringLength(25)]
        public string cost { get; set; }
        // --- khóa ngoại PostCate-Package
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Package))]
        public virtual Post_cate PackageIDNavigation { get; set; }

        //Khóa ngoại PackageCate-Package
        [ForeignKey(nameof(Package_CateID))]
        [InverseProperty(nameof(Package_Cate.Package))]
        public virtual Package_Cate PackageCateIDNavigation { get; set; }
    }
}
