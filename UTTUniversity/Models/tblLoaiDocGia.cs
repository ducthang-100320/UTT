namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLoaiDocGia")]
    public partial class tblLoaiDocGia
    {
        [Key]
        [StringLength(50)]
        public string MA_LOAI { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_LOAI { get; set; }

        public int? TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
