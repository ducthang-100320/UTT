namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDocGia")]
    public partial class tblDocGia
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_DOCGIA { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_LOAI { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_THE { get; set; }

        [Required]
        [StringLength(150)]
        public string TEN_DOCGIA { get; set; }

        public int GIOI_TINH { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_SINH { get; set; }

        [Required]
        [StringLength(15)]
        public string SO_DTHOAI { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
