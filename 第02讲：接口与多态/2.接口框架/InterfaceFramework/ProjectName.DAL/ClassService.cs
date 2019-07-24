using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectName.IDAL;
using ProjectName.Models;
using System.Data.SqlClient;

namespace ProjectName.DAL
{
    public class ClassService : IClassService
    {
        public List<StudentClass> GetAllClass()
        {
            string sql = "select ClassName,ClassId from StudentClass";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (objReader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassName = objReader["ClassName"].ToString(),
                    ClassId = Convert.ToInt32(objReader["ClassId"].ToString())
                });
            }
            objReader.Close();
            return list;
        }
    }
}
