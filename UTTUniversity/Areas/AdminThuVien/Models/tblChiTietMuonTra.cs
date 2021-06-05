namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiTietMuonTra")]
    public partial class tblChiTietMuonTra
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_MUONTRA { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SACH { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
