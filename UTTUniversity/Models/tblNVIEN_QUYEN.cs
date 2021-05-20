namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblNVIEN_QUYEN
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        public virtual tblQuyen tblQuyen { get; set; }
    }
}
