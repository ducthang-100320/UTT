namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblKhenThuong_KyLuat
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NHANVIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string LOAI_HINH { get; set; }

        [Required]
        [StringLength(500)]
        public string LY_DO { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
