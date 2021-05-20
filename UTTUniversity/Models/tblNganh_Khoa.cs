namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblNganh_Khoa
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_CHUYENNGANH { get; set; }

        [StringLength(150)]
        public string TEN_CHUYENNGANH { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_KHOA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public virtual tblKhoa tblKhoa { get; set; }
    }
}
