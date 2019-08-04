﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.War3.Interface
{
    public interface IRace
    {
        void ShowKing();
    }

    public interface IArmy
    {
        void BuildArmy();
    }

    public interface IHero
    {
        void ShowHero();
    }
}
