namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKhoa")]
    public partial class tblKhoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKhoa()
        {
            tblNganh_Khoa = new HashSet<tblNganh_Khoa>();
        }

        [Key]
        [StringLength(50)]
        public string MA_KHOA { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_KHOA { get; set; }

        [Required]
        [StringLength(500)]
        public string DIA_CHI { get; set; }

        public int SO_DIENTHOAI { get; set; }

        [Required]
        [StringLength(500)]
        public string EMAIL { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNganh_Khoa> tblNganh_Khoa { get; set; }
    }
}
