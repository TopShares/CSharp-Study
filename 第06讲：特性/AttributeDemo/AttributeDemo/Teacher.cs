using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [MyCustom]
    [MyCustom(Id = 1000)]
    [MyCustom(Id = 1000, Comment = "实体对象的描述信息")]
    [MyCustom(Id = 1000, IsNotNull = false, Comment = "实体对象的描述信息")]
    [TableByName("Model_Teacher")]
    public class Teacher
    {
        public int TeacherId { get; set; }

      //  [MyCustom(Id = 1000, Comment = "讲师姓名")]
        [MyCustom(Id = 1000, IsNotNull = false, Comment = "讲师姓名：常老师")]
        public string TeacherName { get; set; }
        public int Salary { get; set; }

    }
}
