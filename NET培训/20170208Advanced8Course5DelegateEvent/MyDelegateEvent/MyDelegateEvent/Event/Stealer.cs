﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    public class Stealer
    {
        public void Hide()
        {
            Console.WriteLine("{0} Hide", this.GetType().Name);
        }
    }
}
