using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLInterfaceImpl2
{
    public class StudentLogicImpl : IBLInterface.IStudentLogic
    {
        public List<Student> QueryList(string param1)
        {
            //实际开发中的具体的业务实现。。。

            return new List<Student>
            {
                 new Student { StudentId=1,StudentName="ABC2" },
                 new Student { StudentId=2,StudentName="CDE2" }
            };
        }

        public int StudentTest()
        {

            return 2;
        }
    }
}
