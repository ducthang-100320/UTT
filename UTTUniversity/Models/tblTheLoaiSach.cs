namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTheLoaiSach")]
    public partial class tblTheLoaiSach
    {
        [Key]
        [StringLength(50)]
        public string MA_THELOAI { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_THELOAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
