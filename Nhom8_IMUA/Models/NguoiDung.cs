namespace Nhom8_IMUA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DisplayName("Mã người dùng")]
        [Required(ErrorMessage="Mã người dùng không được để trống")]
        public int MaND { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu dùng không được để trống")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Họ tên dùng không được để trống")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [DisplayName("Ảnh đại diện")]
        [Column(TypeName = "text")]
        public string AnhDaiDien { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(50)]
        public string SoDT { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Loại tai khoản")]
        [Required(ErrorMessage = "Loại tai khoản không được để trống")]
        public bool Loai { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "Trạng thái khoản không được để trống")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
