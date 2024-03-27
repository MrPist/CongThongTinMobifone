using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CongThongTinMobifone.Models
{
    public partial class Number_Type
    {
        public Number_Type()
        {
            Phone_number = new HashSet<Phone_number>();
        }
        [Key]
        [StringLength(50)]
        public string Number_TypeID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Content { get; set; }
        // --- Khóa ngoại Number_Type-Phone_number
        [InverseProperty("Number_TypeIDNavigation")]
        public virtual ICollection<Phone_number> Phone_number { get; set; }
    }
}
