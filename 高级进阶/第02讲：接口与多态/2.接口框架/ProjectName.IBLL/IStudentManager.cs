using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectName.Models;


namespace ProjectName.IBLL
{
    public interface IStudentManager
    {
        string AddStudent(Student objStudent);//添加学员
        int DeleteStudent(Student objStudent);//删除学员      
        List<Student> GetStudentByClass(string className);//根据班级名称查询学员
        Student GetStudentById(string studentId);//根据学号获取学员对象
        bool IsIdNoExisted(string idNo, string studentId);//根据学号和身份证号判断身份证号是否存在
        bool IsIdNoExisted(string studentIdNo);//判断身份证号是否重复
        int ModifyStudent(Student objStudent);//修改学员
    }
}
