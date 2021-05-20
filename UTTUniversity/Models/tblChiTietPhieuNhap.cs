namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiTietPhieuNhap")]
    public partial class tblChiTietPhieuNhap
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_PHIEUNHAP { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SACH { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_THELOAI { get; set; }

        public int SO_LUONG { get; set; }

        [Column(TypeName = "money")]
        public decimal DON_GIA { get; set; }

        [Column(TypeName = "money")]
        public decimal THANH_TIEN { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
