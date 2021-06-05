namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTheLoaiSach")]
    public partial class tblTheLoaiSach
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_THELOAI { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_THELOAI { get; set; }

        public int TRANG_THAI { get; set; }
    }
}
