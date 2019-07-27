namespace CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(2)]
        public string Gender { get; set; }

        public DateTime Dateofbirth { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string StudentAddress { get; set; }

        public int? ClassId { get; set; }

        public virtual StudentClass StudentClass { get; set; }

        public virtual StudentCard StudentCard { get; set; }
    }
}
