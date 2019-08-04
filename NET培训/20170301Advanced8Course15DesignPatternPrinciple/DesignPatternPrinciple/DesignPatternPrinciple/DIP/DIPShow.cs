using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    public class DIPShow
    {
        public static void Show()
        {
            Console.WriteLine("*****************************");
            Student student = new Student()
            {
                Id = 191,
                Name = "候鸟"
            };
            {
                iPhone phone = new iPhone();
                student.PlayiPhone(phone);
                student.PlayPhone(phone);
            }
            {
                Lumia phone = new Lumia();
                student.PlayLumia(phone);
                student.PlayPhone(phone);
            }
            {
                Honor phone = new Honor();
                student.PlayHonor(phone);
                student.PlayPhone(phone);
            }
            {
                Mi phone = new Mi();
                //student.PlayHonor(phone);
                student.PlayPhone(phone);
            }
        }
    }
}
