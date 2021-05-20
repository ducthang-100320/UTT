namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDiem")]
    public partial class tblDiem
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SINHVIEN { get; set; }

        [StringLength(10)]
        public string MA_HOCPHAN { get; set; }

        public int LAN_HOC { get; set; }

        public int LAN_THI { get; set; }

        public double DIEM_CC { get; set; }

        public double DIEM_GK { get; set; }

        public int DIEM_THI { get; set; }

        public int TRANG_THAI { get; set; }

        public virtual tblSinhVien tblSinhVien { get; set; }
    }
}
