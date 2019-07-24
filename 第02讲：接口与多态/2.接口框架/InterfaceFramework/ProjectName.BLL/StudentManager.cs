using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectName.IBLL;
using ProjectName.Models;
using ProjectName.IDAL;

namespace ProjectName.BLL
{
    public class StudentManager : IStudentManager
    {
        private IStudentService iService = new DAL.StudentService();

        public string AddStudent(Student objStudent)
        {
            if (iService.IsIdNoExisted(objStudent.StudentIdNo))
            {
                return "身份证号不能重复！";
            }
            try
            {
                //调用数据访问方法
                iService.AddStudent(objStudent);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int DeleteStudent(Student objStudent)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentByClass(string className)
        {
            if (className == null || className.Length == 0)
                return iService.GetStudent();
            else
                return iService.GetStudentByClass(className);
        }
            

        public Student GetStudentById(string studentId)
        {
            throw new NotImplementedException();
        }

        public bool IsIdNoExisted(string studentIdNo)
        {
            throw new NotImplementedException();
        }

        public bool IsIdNoExisted(string idNo, string studentId)
        {
            throw new NotImplementedException();
        }

        public int ModifyStudent(Student objStudent)
        {
            throw new NotImplementedException();
        }
    }
}
