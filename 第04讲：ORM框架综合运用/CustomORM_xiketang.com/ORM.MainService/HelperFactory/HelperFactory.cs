
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ORM.MainService
{
    /// <summary>
    /// 通用数据访问对象工厂
    /// </summary>
    public class HelperFactory
    {
        //Access数据库访问类
        public static IBaseDALHelper<OleDbDataReader, OleDbParameter> OleDbHelper =
            new ImplBaseDALHelper<OleDbConnection, OleDbCommand, OleDbDataReader, OleDbParameter>();

        //SqlServer数据访问类
        public static IBaseDALHelper<SqlDataReader, SqlParameter> SQLHelper =
           new ImplBaseDALHelper<SqlConnection, SqlCommand, SqlDataReader, SqlParameter>();

        //其他数据访问类...





    }
}
