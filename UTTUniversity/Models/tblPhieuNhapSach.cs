namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPhieuNhapSach")]
    public partial class tblPhieuNhapSach
    {
        [Key]
        [StringLength(50)]
        public string MA_PHIEU { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NHANVIEN { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_NHAP { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NXB { get; set; }

        [Required]
        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
