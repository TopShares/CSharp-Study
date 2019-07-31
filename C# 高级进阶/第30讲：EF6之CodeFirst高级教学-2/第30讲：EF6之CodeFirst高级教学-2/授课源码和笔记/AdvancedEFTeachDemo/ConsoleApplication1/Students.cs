namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            ScoreList = new HashSet<ScoreList>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(2)]
        public string Gender { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "numeric")]
        public decimal StudentIdNo { get; set; }

        public int Age { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string StudentAddress { get; set; }

        public int ClassId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreList> ScoreList { get; set; }

        public virtual StudentClass StudentClass { get; set; }
    }
}
