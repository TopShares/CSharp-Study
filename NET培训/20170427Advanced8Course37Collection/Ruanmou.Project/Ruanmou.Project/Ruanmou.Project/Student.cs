using Ruanmou.Interface;
//using Ruanmou.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Project
{
    public class Student
    {
        //public void PlayApplePhone(ApplePhone phone)
        //{
        //    phone.Call();
        //}
        //public void PlayAndroidPhone(AndroidPhone phone)
        //{
        //    phone.Call();
        //}
        public void PlayPhone(IPhone phone)
        {
            phone.Call();
        }

    }
}
