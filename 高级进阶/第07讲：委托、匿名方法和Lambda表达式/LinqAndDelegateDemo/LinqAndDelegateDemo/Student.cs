using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndDelegateDemo
{
    public sealed class Student : Person
    {
        public int Age { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
