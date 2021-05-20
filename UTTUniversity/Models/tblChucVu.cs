namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChucVu")]
    public partial class tblChucVu
    {
        [Key]
        [StringLength(50)]
        public string MA_CHUCVU { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_CHUCVU { get; set; }

        [StringLength(150)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
