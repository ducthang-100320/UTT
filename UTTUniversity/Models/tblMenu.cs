namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMenu")]
    public partial class tblMenu
    {
        public int ID { get; set; }

        public int Parent_ID { get; set; }

        public int TypeMenu { get; set; }

        [Required]
        [StringLength(50)]
        public string UserControl { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuName { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public int? CategoryID { get; set; }

        public int? NewsID { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(300)]
        public string Page { get; set; }

        public int OrderNumber { get; set; }

        [StringLength(200)]
        public string MetaTitle { get; set; }

        public int Status { get; set; }
    }
}
