using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Diagnostics.CodeAnalysis;

namespace CongThongTinMobifone.Models
{
    public partial class Phone_number
    {
        [StringLength(10)]
        [Key]
        public string Number { get; set; }
        [StringLength(50)]
        public string Number_TypeID { get; set; }
        [StringLength(50)]
        public string PostCateID { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        // --- khóa ngoại Number_Type-Phone_number
        [ForeignKey(nameof(Number_TypeID))]
        [InverseProperty(nameof(Number_Type.Phone_number))]
        public virtual Number_Type Number_TypeIDNavigation { get; set; }

        // --- khóa ngoại PostCate-Phone_number
        [ForeignKey(nameof(PostCateID))]
        [InverseProperty(nameof(Post_cate.Phone_number))]
        public virtual Post_cate Phone_numberIDNavigation { get; set; }
    }
    //public class MyContext : DbContext
    //{
    //    public DbSet<Phone_number> MyEntities { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Phone_number>()
    //            .HasKey(e => new { e.Number_MAC, e.Number });
    //    }
    //}
}
