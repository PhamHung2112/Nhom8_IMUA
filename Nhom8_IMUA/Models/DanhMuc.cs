namespace Nhom8_IMUA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            LoaiSPs = new HashSet<LoaiSP>();
        }

        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDM { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string AnhDM { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string BieuTuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiSP> LoaiSPs { get; set; }
    }
}
