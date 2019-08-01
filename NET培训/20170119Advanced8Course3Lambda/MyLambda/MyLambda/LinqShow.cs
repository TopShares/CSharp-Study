using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLambda.Extend;

namespace MyLambda
{
    public class LinqShow
    {

        private List<Student> GetStudentList()
        {
            #region 初始化数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="打兔子的猎人",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="Alpha Go",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="白开水",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="狼牙道",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="Nine",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="Y",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="小昶",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="yoyo",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="冰亮",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="瀚",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="毕帆",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="一点半",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="小石头",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="大海",
                    ClassId=2,
                    Age=30
                },
            };
            #endregion
            return studentList;
        }


        public void Show()
        {
            List<Student> studentList = this.GetStudentList();

            List<Student> studentListlessThan30 = new List<Student>();
            foreach (var item in studentList)
            {
                if (item.Age < 30)
                {
                    studentListlessThan30.Add(item);
                }
            }



            {
                var list = studentList.Where<Student>(s => s.Age < 30);//陈述句
                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
                }
            }
            {
                Console.WriteLine("********************");
                var list = studentList.ElevenWhere<Student>(s => s.Age < 30);//陈述句

                //Func<Student, bool> func = new Func<Student, bool>(s => s.Age < 30);
                //var list = ExtendShow.ElevenWhere<Student>(studentList,func);//陈述句
                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
                }
            }
            {
                Console.WriteLine("********************");
                var list = from s in studentList
                           where s.Age < 30
                           select s;

                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
                }
            }


            {
                Console.WriteLine("********************");
                var list = studentList.Where<Student>(s => s.Age < 30)
                                     .Select(s => new
                                     {
                                         IdName = s.Id + s.Name,
                                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                                     });
                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                }
            }
            {
                Console.WriteLine("********************");
                var list = from s in studentList
                           where s.Age < 30
                           select new
                           {
                               IdName = s.Id + s.Name,
                               ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                           };

                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                }
            }
            {
                Console.WriteLine("********************");
                var list = studentList.Where<Student>(s => s.Age < 30)
                                     .Select(s => new
                                     {
                                         Id = s.Id,
                                         ClassId = s.ClassId,
                                         IdName = s.Id + s.Name,
                                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                                     })
                                     .OrderBy(s => s.Id)
                                     .OrderByDescending(s => s.ClassId)
                                     .Skip(2)
                                     .Take(3)
                                     ;
                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                }
            }
            {
                List<Class> classList = new List<Class>()
                {
                    new Class()
                    {
                        Id=1,
                        ClassName="初级班"
                    },
                    new Class()
                    {
                        Id=2,
                        ClassName="高级班"
                    },
                    new Class()
                    {
                        Id=3,
                        ClassName="微信小程序"
                    },
                };

                var list = from s in studentList
                           join c in classList on s.ClassId equals c.Id
                           select new
                           {
                               Name = s.Name,
                               CalssName = c.ClassName
                           };
            }

        }

    }
}
