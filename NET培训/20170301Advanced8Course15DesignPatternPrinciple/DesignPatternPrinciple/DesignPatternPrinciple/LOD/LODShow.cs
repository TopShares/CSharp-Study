using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
    public class LODShow
    {
        public static void Show()
        {
            Console.WriteLine("************************");
            School school = new School()
            {
                SchoolName = "软谋教育",
                ClassList = new List<Class>()
                {
                    new Class()
                    {
                        ClassName="高级班",
                        StudentList=new List<Student>()
                        {
                            new Student()
                            {
                                StudentName="yoyo"
                            }
                        }
                    }
                }
            };

            school.Manage();
        }
    }
}
