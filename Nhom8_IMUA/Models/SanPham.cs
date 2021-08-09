namespace Nhom8_IMUA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string AnhDaiDien { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        public int KhuyenMai { get; set; }

        [Required]
        [StringLength(4000)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(100)]
        public string XuatXu { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TrongLuong { get; set; }

        public int MaLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }
    }
}
