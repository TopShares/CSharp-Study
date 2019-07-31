using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectName.Models;

namespace ProjectName.IBLL
{
    public interface IClassManager
    {
        List<StudentClass> GetAllClass();
    }
}
