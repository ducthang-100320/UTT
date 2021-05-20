namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHocPhi")]
    public partial class tblHocPhi
    {
        [Key]
        [StringLength(50)]
        public string MA_HOCPHI { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SINHVIEN { get; set; }

        [Column(TypeName = "money")]
        public decimal TONG_SO { get; set; }

        [Column(TypeName = "money")]
        public decimal DA_DONG { get; set; }

        [Column(TypeName = "money")]
        public decimal? CON_NO { get; set; }

        [Column(TypeName = "money")]
        public decimal? CON_DU { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public virtual tblSinhVien tblSinhVien { get; set; }
    }
}
