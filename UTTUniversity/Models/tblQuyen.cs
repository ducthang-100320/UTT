namespace UTTUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQuyen")]
    public partial class tblQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblQuyen()
        {
            tblNVIEN_QUYEN = new HashSet<tblNVIEN_QUYEN>();
        }

        [Key]
        [StringLength(20)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNVIEN_QUYEN> tblNVIEN_QUYEN { get; set; }
    }
}
