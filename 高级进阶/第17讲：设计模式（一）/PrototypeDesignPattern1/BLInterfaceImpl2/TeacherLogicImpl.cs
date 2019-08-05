using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBLInterface;
using Models;

namespace BLInterfaceImpl2
{
    public class TeacherLogicImpl : ITeacherLogic
    {
        public Teacher GetObject(int param1)
        {
            //实际开发中，请在这里添加业务逻辑
            return new Teacher { TeacherName = "张老师", PhoneNumber = "13600000002" };
        }

        public string Query(string param1, string param2)
        {

            return $"2param1={param1}   2param2={param2}";
        }



    }
}
