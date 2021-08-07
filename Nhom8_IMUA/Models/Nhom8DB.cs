using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Nhom8_IMUA.Models
{
    public partial class Nhom8DB : DbContext
    {
        public Nhom8DB()
            : base("name=Nhom8DB")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<QuanTri> QuanTris { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.AnhDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.BieuTuong)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.PhiVanChuyen)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaMoi)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaCu)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.TrongLuong)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.AnhTinTuc)
                .IsUnicode(false);
        }
    }
}
