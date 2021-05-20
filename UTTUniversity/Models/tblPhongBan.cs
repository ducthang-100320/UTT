namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPhongBan")]
    public partial class tblPhongBan
    {
        [Key]
        [StringLength(50)]
        public string MA_PHONGBAN { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_PHONGBAN { get; set; }

        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [StringLength(15)]
        public string SO_DTHOAI { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
