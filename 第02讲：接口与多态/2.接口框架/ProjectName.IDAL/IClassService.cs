using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectName.Models;

namespace ProjectName.IDAL
{
    public interface IClassService
    {
        List<StudentClass> GetAllClass();
    }
}
