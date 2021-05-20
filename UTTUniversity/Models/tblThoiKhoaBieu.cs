namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblThoiKhoaBieu")]
    public partial class tblThoiKhoaBieu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_HOCPHAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_GIANGVIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string THOI_GIAN { get; set; }

        public DateTime NGAY_BDAU { get; set; }

        public DateTime NGAY_KTHUC { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
