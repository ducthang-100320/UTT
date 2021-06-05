namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNhanVien")]
    public partial class tblNhanVien
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NHANVIEN { get; set; }

        public int Account_ID { get; set; }

        [Required]
        [StringLength(150)]
        public string HO_TEN { get; set; }

        public DateTime NGAY_SINH { get; set; }

        public int GIOI_TINH { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(15)]
        public string SO_DIENTHOAI { get; set; }

        [Required]
        [StringLength(200)]
        public string QUE_QUAN { get; set; }

        [Required]
        [StringLength(350)]
        public string DIA_CHI { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [StringLength(50)]
        public string MA_CHUCVU { get; set; }

        [StringLength(50)]
        public string MA_TRINHDO { get; set; }

        public int TRANGTHAI { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
