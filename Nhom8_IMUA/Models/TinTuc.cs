namespace Nhom8_IMUA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int MaTinTuc { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [DisplayName("Tiêu đề")]
        [StringLength(100)]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Tóm tắt không được để trống")]
        [DisplayName("Tóm tắt")]
        [StringLength(1000)]
        public string TomTat { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [DisplayName("Nội dung")]
        [StringLength(4000)]
        public string NoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Ảnh tin tức không được để trống")]
        [DisplayName("Ảnh tin tức")]
        public string AnhTinTuc { get; set; }
    }
}
