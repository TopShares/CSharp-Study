namespace CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysAdmin")]
    public partial class SysAdmin
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [StringLength(20)]
        public string LoginPwd { get; set; }

        [Required]
        [StringLength(20)]
        public string AdminName { get; set; }
    }
}
