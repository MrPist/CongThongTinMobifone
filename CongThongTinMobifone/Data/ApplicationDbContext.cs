using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CongThongTinMobifone.Models;

namespace CongThongTinMobifone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CongThongTinMobifone.Models.Post>? Post { get; set; }
        public DbSet<CongThongTinMobifone.Models.Post_cate>? Post_cate { get; set; }
        public DbSet<CongThongTinMobifone.Models.Number_Type>? Number_Type { get; set; }
        public DbSet<CongThongTinMobifone.Models.Phone_number>? Phone_number { get; set; }
        public DbSet<CongThongTinMobifone.Models.Package>? Package { get; set; }
        public DbSet<CongThongTinMobifone.Models.Package_Cate>? Package_Cate { get; set; }
    }
}
