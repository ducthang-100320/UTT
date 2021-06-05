namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBanner")]
    public partial class tblBanner
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Content { get; set; }

        [Required]
        [StringLength(150)]
        public string ImagePath { get; set; }

        [StringLength(150)]
        public string BannerUrl { get; set; }
    }
}
