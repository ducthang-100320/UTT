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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MA_TACGIA { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string TEN_TACGIA { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string IMAGE { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GIOI_TINH { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime NGAY_SINH { get; set; }

        public string MO_TA { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TRANG_THAI { get; set; }
    }
}
