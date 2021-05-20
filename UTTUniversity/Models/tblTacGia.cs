namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTacGia")]
    public partial class tblTacGia
    {
        [Key]
        [StringLength(50)]
        public string MA_TACGIA { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_TACGIA { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
