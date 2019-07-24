using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectName.DAL;
using ProjectName.Models;
using ProjectName.IBLL;
using ProjectName.IDAL;

namespace ProjectName.BLL
{
    public class ClassManager : IClassManager
    {
        //创建数据访问对象
        private IClassService iService = new ClassService();
        public List<StudentClass> GetAllClass()
        {
            return iService.GetAllClass();
        }
    }
}
