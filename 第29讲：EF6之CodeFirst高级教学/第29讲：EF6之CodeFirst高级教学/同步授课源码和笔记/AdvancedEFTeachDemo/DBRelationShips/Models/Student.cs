using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRelationShips
{
    [Table("StudentMaster")]
    public class Student
    {
        //public int StudentId{ get; set; }

        [Key]
        public int Studentkey { get; set; }

        [Column("Name")]
        [MaxLength(20)]
        public string StudentName { get; set; }

        [Required]
        [MaxLength(2)]
        public string Gender { get; set; }

        [NotMapped]//这个一般是业务需要，而添加的扩展属性，没有字段对应
        public int Age { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ConcurrencyCheck]//添加这个特性后，对应的字段，每次在update的时候都会带着这个字段作为where条件。
        public string PhoneNumber { get; set; }

        public StudentCard StudentCard { get; set; }

        public StudentClass StudentClass { get; set; }

        public ICollection<Course> Course { get; set; }

    }
}
