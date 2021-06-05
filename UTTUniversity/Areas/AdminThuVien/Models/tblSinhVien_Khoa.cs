namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblSinhVien_Khoa
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SINHVIEN { get; set; }

        [StringLength(10)]
        public string MA_KHOA { get; set; }

        public virtual tblSinhVien tblSinhVien { get; set; }
    }
}
