namespace Nhom8_IMUA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    [Serializable]
    public partial class Credential
    {
        public long CredentialID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleID { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
