namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblNews_File
    {
        public int ID { get; set; }

        public int NewsID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
    }
}
