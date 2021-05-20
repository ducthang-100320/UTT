namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblNew
    {
        public int ID { get; set; }

        public int CateNewsID { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string ShortDescribe { get; set; }

        [Required]
        public string FullDescribe { get; set; }

        [StringLength(200)]
        public string ImageThumb { get; set; }

        [StringLength(200)]
        public string ImageLarge { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        public DateTime? PostDate { get; set; }

        public int Language { get; set; }

        public int IsHot { get; set; }

        public int IsView { get; set; }

        public int IsComment { get; set; }

        public int IsApproval { get; set; }

        [StringLength(100)]
        public string ApprovalUser { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int CommentTotal { get; set; }

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
