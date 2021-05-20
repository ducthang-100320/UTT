namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHocPhan")]
    public partial class tblHocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHocPhan()
        {
            tblSinhVien_HocPhan = new HashSet<tblSinhVien_HocPhan>();
        }

        [Key]
        [StringLength(50)]
        public string MA_HOCPHAN { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_HOCPHAN { get; set; }

        public int SO_TC { get; set; }

        public int SO_TIET { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinhVien_HocPhan> tblSinhVien_HocPhan { get; set; }
    }
}
