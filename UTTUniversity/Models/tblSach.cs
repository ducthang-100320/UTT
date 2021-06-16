namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSach")]
    public partial class tblSach
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SACH { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_SACH { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_TACGIA { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_THELOAI { get; set; }


        public int SO_LUONG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NXB { get; set; }

        [StringLength(200)]
        public string IMAGE { get; set; }

        [StringLength(300)]
        public string MO_TA { get; set; }

        public int TRANG_THAI { get; set; }
    }
}
