using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Post_content { get; set; }
        public DateTime Date_created { get; set; }
        public DateTime Date_update { get; set; }
        public bool active { get; set; }

        // --- khóa ngoại PostCate-Post
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Post))]
        public virtual Post_cate PostIDNavigation { get; set; }
    }
}
