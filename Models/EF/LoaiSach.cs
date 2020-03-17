namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSach")]
    public partial class LoaiSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSach()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên loại")]
        [StringLength(50, ErrorMessage = "Tên loại không được vượt quá 50 ký tự")]
        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
