namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMuonTra")]
    public partial class tblMuonTra
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SACH { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_DOCGIA { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày mượn")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_MUON { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập số lượng")]
        public int SO_LUONG { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập ngày trả")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_TRA { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
