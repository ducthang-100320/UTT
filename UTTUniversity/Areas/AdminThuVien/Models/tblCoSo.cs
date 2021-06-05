namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCoSo")]
    public partial class tblCoSo
    {
        [Key]
        [StringLength(50)]
        public string MA_COSO { get; set; }

        [Required]
        [StringLength(300)]
        public string TEN_COSO { get; set; }

        [Required]
        [StringLength(300)]
        public string DIA_CHI { get; set; }

        [Required]
        [StringLength(15)]
        public string SO_DTHOAI { get; set; }

        [StringLength(15)]
        public string FAX { get; set; }

        [Required]
        [StringLength(300)]
        public string EMAIL { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
