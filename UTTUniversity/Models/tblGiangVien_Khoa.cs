namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblGiangVien_Khoa
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_GIANGVIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_KHOA { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
