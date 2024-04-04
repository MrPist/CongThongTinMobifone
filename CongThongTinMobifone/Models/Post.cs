using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Options;

namespace CongThongTinMobifone.Models
{
    public partial class Post
    {
        [Key]
        [StringLength(50)]
        public string PostID { get; set; }
        [StringLength(50)]
        public string PostCateID { get; set; }
        [StringLength(250)]
        public string Post_title { get; set; }
        public string Post_content1 { get; set; }
        public string Post_content2 { get; set; }
        public string Post_content3 { get; set; }
        public string Post_content4 { get; set; }
        public string avatar { get; set; }
        [StringLength(255)]
        public string img1 { get; set; }
        [StringLength(255)]
        public string img2 { get; set; }
        [StringLength(255)]
        public string img3 { get; set; }
        public DateTime Date_created { get; set; }
        public DateTime Date_update { get; set; }

        // --- khóa ngoại PostCate-Post
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Post))]
        public virtual Post_cate PostIDNavigation { get; set; }
    }
}
