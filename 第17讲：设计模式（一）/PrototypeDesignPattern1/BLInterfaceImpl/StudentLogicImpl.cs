using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLInterfaceImpl1
{
    public class StudentLogicImpl : IBLInterface.IStudentLogic
    {
        public List<Student> QueryList(string param1)
        {
            //实际开发中的具体的业务实现。。。

            return new List<Student>
            {
                 new Student { StudentId=1,StudentName="ABC1" },
                 new Student { StudentId=2,StudentName="CDE1" }
            };
        }

        public int StudentTest()
        {

            return 1;
        }
    }
}
