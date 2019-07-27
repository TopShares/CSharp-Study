using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBLInterface;
using Models;

namespace BLInterfaceImpl1
{
    public class TeacherLogicImpl : ITeacherLogic
    {
        public Teacher GetObject(int param1)
        {
            //实际开发中，请在这里添加业务逻辑
            return new Teacher { TeacherName = "常老师", PhoneNumber = "13600000001" };
        }

        public string Query(string param1, string param2)
        {

            return $"1param1={param1}   1param2={param2}";
        }



    }
}
