namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTrinhDoHocVan")]
    public partial class tblTrinhDoHocVan
    {
        [Key]
        [StringLength(50)]
        public string MA_TRINHDO { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_TRINHDO { get; set; }

        [Required]
        [StringLength(50)]
        public string CHUYEN_NGANH { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        [Required]
        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
