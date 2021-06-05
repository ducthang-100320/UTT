namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblVideo")]
    public partial class tblVideo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [StringLength(300)]
        public string ShortDescribe { get; set; }

        [StringLength(200)]
        public string VideoUrl { get; set; }

        [StringLength(200)]
        public string FileUrl { get; set; }

        public int Language { get; set; }

        public DateTime? PostDate { get; set; }

        public int IsHome { get; set; }

        [StringLength(100)]
        public string VideoType { get; set; }

        public int? Approval { get; set; }

        [StringLength(50)]
        public string ApprovalUser { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedUser { get; set; }
    }
}
