using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void PlayiPhone(iPhone phone)
        {
            Console.WriteLine("这里是{0}", this.Name);
            phone.Call();
            phone.Text();
        }

        public void PlayLumia(Lumia phone)
        {
            Console.WriteLine("这里是{0}", this.Name);
            phone.Call();
            phone.Text();
            //phone.New();
        }

        public void PlayHonor(Honor phone)
        {
            Console.WriteLine("这里是{0}", this.Name);
            phone.Call();
            phone.Text();
        }

        public void PlayPhone(AbstractPhone phone)
        {
            Console.WriteLine("这里是{0}", this.Name);
            phone.Call();
            phone.Text();
        }

        public void Play<T>(T phone) where T : AbstractPhone
        {
            Console.WriteLine("这里是{0}", this.Name);
            phone.Call();
            phone.Text();
        }
    }
}
