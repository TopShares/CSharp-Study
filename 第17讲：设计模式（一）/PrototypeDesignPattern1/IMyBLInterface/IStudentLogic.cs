using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLInterface
{
    public interface IStudentLogic
    {
        int StudentTest();

        List<Student> QueryList(string param1);

        //根据需要继续添加其他接口...
    }
}
