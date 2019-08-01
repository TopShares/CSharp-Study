using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NhibernateShow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateShow
{
    /// <summary>
    /// 访问基类
    /// </summary>
    public class BaseDAL
    {
        public T Get<T>(int id) where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                return iSession.Get<T>(id);
            }
        }

        public object Save<T>(T t) where T : BaseModel
        {
            using (ISession session = NhibernateFactory.CreateSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    try
                    {
                        var id = session.Save(t);
                        session.Flush();//执行sql
                        tran.Commit();//完成提交
                        return id;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Update<T>(T t) where T : BaseModel
        {
            using (ISession session = NhibernateFactory.CreateSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(t);
                        session.Flush();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public bool SaveOrUpdate<T>(T t) where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                iSession.SaveOrUpdate(t);
                iSession.Flush();
                return true;
            }
        }

        public bool Delete<T>(T t) where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                iSession.Delete(t);
                iSession.Flush();
                return true;
            }
        }




        /// <summary>
        /// 直接执行查询sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<T> GetListBySql<T>(string sql)
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                ISQLQuery sqlQuery = iSession.CreateSQLQuery(sql);//.AddEntity(typeof(T));
                return sqlQuery.List<T>();
            }
        }

        /// <summary>
        /// 直接参数化执行sql
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteSql(string sql)
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                IDbConnection conn = iSession.Connection;

                IDbCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * from [User] WHERE Id=@Id";
                cmd.CommandType = CommandType.Text;
                IDbDataParameter parameter = cmd.CreateParameter();
                parameter.ParameterName = "Id";
                parameter.Value = 131;
                cmd.Parameters.Add(parameter);
                //cmd.ExecuteNonQuery();
                object oValue = cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// HQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> GetCustomerListByType<T>(int id) where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {

                //var list = from a in new List<int>()
                //           where a > 1
                //           select a;

                string hql = string.Format("from {0} where ID='{1}'", typeof(T).Name, id);
                return iSession.CreateQuery(hql).List<T>();
            }
        }


        /// <summary>
        /// Criteria：fluent
        /// </summary>
        /// <returns></returns>
        public IList<T> CreateCriteria<T>(int id)
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                ICriteria crit = iSession
                    .CreateCriteria(typeof(T))
                    //.Add(Restrictions.Eq("id", id))
                    .Add(Restrictions.Like("CustomName", "小%"))
                    .AddOrder(new Order("CreateTime", false))
                    .SetMaxResults(50);
                return crit.List<T>();
            }
        }


        /// <summary>
        /// linq to sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<T> QueryList<T>(Expression<Func<T, bool>> expression) where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                return iSession.Query<T>().Where(expression).ToList();
            }
        }

        /// <summary>
        /// Linq
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public IQueryable<T> List<T>() where T : BaseModel
        {
            using (ISession iSession = NhibernateFactory.CreateSession())
            {
                return iSession.Query<T>();
            }
        }

    }
}
