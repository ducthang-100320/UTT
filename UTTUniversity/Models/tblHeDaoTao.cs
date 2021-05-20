namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHeDaoTao")]
    public partial class tblHeDaoTao
    {
        [Key]
        [StringLength(50)]
        public string MA_HE { get; set; }

        [Required]
        [StringLength(100)]
        public string TEN_HE { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
