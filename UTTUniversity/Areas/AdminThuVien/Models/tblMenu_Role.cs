namespace ThuVienTruongHoc.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMenu_Role
    {
        public int ID { get; set; }

        public int MenuID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleID { get; set; }
    }
}
