using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    /// <summary>
    /// 扩展方法类
    /// </summary>
    static class ExtendMethod
    {

        public static int GetAvg(this int sum)
        {
            return sum / 5;
        }

        public static string StuInfo(this string name)
        {
            return string.Format("{0} 您好，您的5门平均成绩为：", name);
        }

        //为密封类Student添加扩展方法
        public static string ShowStuInfo(this Student objStudent)
        {
            return "欢迎您：" + objStudent.StudentName;
        }
        public static string ShowStuInfo(this Student objStudent, int csharp, int database)
        {
            int avg = (csharp + database) / 2;
            return string.Format("欢迎您：{0}  您两门的平均成绩为：{1}", objStudent.StudentName, avg);
        }

    }
}
