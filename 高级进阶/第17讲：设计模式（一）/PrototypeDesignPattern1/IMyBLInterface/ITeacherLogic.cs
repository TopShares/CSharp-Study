using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLInterface
{
    public interface ITeacherLogic
    {
        Teacher GetObject(int param1);

        string Query(string param1, string param2);

        //。。。
    }
}
