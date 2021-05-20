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
        [Key]
        [StringLength(50)]
        public string MA_MUONTRA { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_NV { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_DOCGIA { get; set; }

        public DateTime NGAY_MUON { get; set; }

        public DateTime NGAY_TRA { get; set; }

        public int TRANG_THAI { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }
    }
}
