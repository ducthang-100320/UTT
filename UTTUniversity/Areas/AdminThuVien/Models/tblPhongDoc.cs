namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPhongDoc")]
    public partial class tblPhongDoc
    {
        [Key]
        [StringLength(50)]
        public string MA_PHONG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SINHVIEN { get; set; }

        public DateTime NGAY_DKY { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
