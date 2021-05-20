namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNhaXuatBan")]
    public partial class tblNhaXuatBan
    {
        [Key]
        [StringLength(50)]
        public string MA_NXB { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_NXB { get; set; }

        [Required]
        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [Required]
        [StringLength(15)]
        public string SO_DTHOAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
