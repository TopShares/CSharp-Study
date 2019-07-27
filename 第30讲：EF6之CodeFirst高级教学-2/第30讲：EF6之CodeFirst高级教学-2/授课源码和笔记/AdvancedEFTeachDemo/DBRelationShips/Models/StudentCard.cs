using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRelationShips
{
    public class StudentCard
    {
        // public int StudentId { get; set; }//学号（和Student表一对一）

        [ForeignKey("Student")]
        public int StudentCardId { get; set; }   //默认情况下主键就是在Model后面添加ID后缀

       // [Index]//索引关系
        public string CardType { get; set; }//一卡通的类型

        //一对一
        public Student Student { get; set; }

    }
}
