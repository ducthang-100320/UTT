namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSinhVien")]
    public partial class tblSinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSinhVien()
        {
            tblDiems = new HashSet<tblDiem>();
            tblHocPhis = new HashSet<tblHocPhi>();
            tblSinhVien_HocPhan = new HashSet<tblSinhVien_HocPhan>();
            tblSinhVien_Khoa = new HashSet<tblSinhVien_Khoa>();
        }

        [Key]
        [StringLength(50)]
        public string MA_SINHVIEN { get; set; }

        [Required]
        [StringLength(200)]
        public string HO_TEN { get; set; }

        public DateTime NGAY_SINH { get; set; }

        public int GIOI_TINH { get; set; }

        [Required]
        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [Required]
        [StringLength(15)]
        public string SO_DTHOAI { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        public int TINH_TRANG { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDiem> tblDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHocPhi> tblHocPhis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinhVien_HocPhan> tblSinhVien_HocPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinhVien_Khoa> tblSinhVien_Khoa { get; set; }
    }
}
