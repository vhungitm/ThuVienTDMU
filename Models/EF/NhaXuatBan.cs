namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaXuatBan")]
    public partial class NhaXuatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaXuatBan()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        public int MaNXB { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên nhà xuất bản")]
        [StringLength(50, ErrorMessage = "Tên nhà xuất bản không được vượt quá 50 ký tự")]
        public string TenNXB { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [StringLength(150, ErrorMessage = "Địa chỉ không được vượt quá 150 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
