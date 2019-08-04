using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
    /// <summary>
    /// 学校
    /// </summary>
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }

        public List<Class> ClassList { get; set; }


        public void Manage()
        {
            Console.WriteLine("Manage {0}", this.GetType().Name);
            foreach (Class c in this.ClassList)
            {
                Console.WriteLine(" {0}Manage {1} ", c.GetType().Name, c.ClassName);

                c.Manage();

                //List<Student> studentList = c.StudentList;
                //foreach (Student s in studentList)
                //{
                //    Console.WriteLine(" {0}Manage {1} ", s.GetType().Name, s.StudentName);
                //}

            }
        }


    }
}
