using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongThongTinMobifone.Models
{
    public partial class Post_cate
    {
        public Post_cate()
        {
            Package = new HashSet<Package>();
            Phone_number = new HashSet<Phone_number>();
            Post = new HashSet<Post>();
        }
        [Key]
        [StringLength(50)]
        public string PostCateID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }

        // --- Khóa ngoại Postcate-Post
        [InverseProperty("PostIDNavigation")]
        public virtual ICollection<Post> Post { get; set; }

        // --- Khóa ngoại Postcate-Phone_number
        [InverseProperty("Phone_numberIDNavigation")]
        public virtual ICollection<Phone_number> Phone_number { get; set; }

        // --- Khóa ngoại Postcate-Package
        [InverseProperty("PackageIDNavigation")]
        public virtual ICollection<Package> Package { get; set; }
    }
}
