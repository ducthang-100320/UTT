namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLop")]
    public partial class tblLop
    {
        [Key]
        [StringLength(50)]
        public string MA_LOP { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_LOP { get; set; }

        [Required]
        [StringLength(100)]
        public string GV_CHUNHIEM { get; set; }

        public int SI_SO { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
