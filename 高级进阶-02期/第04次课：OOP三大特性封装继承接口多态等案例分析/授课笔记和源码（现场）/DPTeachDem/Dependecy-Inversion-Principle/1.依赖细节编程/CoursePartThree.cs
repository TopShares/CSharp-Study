﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP1
{
    public class CoursePartThree
    {
        public string CourseName { get; set; } = "微信小程序";
        public string TeacherName { get; set; } = "晓晓老师";
        public int Period { get; set; } = 10;

        public void Attend()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"欢迎大家参加本课程第三阶段学习，我是课程主讲{TeacherName}");
            Console.WriteLine($"我正在学习{TeacherName}主讲的课程:{CourseName} 总结：{Period}课时");
        }
        public void SubmitHomework()
        {
            Console.WriteLine("我现在在提交第三阶段的作业！");
        }

        public void Exam()
        {
            Console.WriteLine("我现在参加第三阶段的考试！");
        }
    }
}
