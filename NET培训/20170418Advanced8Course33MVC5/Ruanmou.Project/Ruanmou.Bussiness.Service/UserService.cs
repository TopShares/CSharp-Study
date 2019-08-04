using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Service
{
    public class UserService : BaseService
    {
        public void LastLogin(User user)
        {
            using (JDContext context = new JDContext())
            {
                user.LastLoginTime = DateTime.Now;
                context.SaveChanges();
            }
        }


        //public User Find(int id)
        //{
        //    using (JDContext context = new JDContext())
        //    {
        //        User user = context.Set<User>().Find(id);
        //        return user;
        //    }
        //}

        //public void Add(User user)
        //{ }

        //public void Update(User user)
        //{ }

        //public void Delete(User user)
        //{ }

        //public void List(User user)
        //{ }
    }
}
