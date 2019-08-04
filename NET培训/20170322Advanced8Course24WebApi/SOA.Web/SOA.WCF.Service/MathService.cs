using SOA.WCF.Model;
using SOA.WCF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Service
{
    public class MathService : IMathService
    {
        public int PlusInt(int x, int y)
        {
            return x + y;
        }

        public WCFUser GetUser(int x, int y)
        {
            return new WCFUser()
            {
                Id = 13,
                Name = "慕冬",
                Age = 22,
                Description = "这里是WCFServie",
                Sex = (int)WCFUserSex.Famale
            };
        }

        public List<WCFUser> UserList()
        {
            return new List<WCFUser>(){ 
                new WCFUser()
                {
                    Id = 1,
                    Name = "只想简简单单的活着",
                    Sex = (int)WCFUserSex.Male,
                    Age = 12,
                    Description = "123456678990"
                },
                 new WCFUser()
                {
                    Id = 2,
                    Name = "謹記妳容顏",
                    Sex = (int)WCFUserSex.Male,
                    Age = 12,
                    Description = "123456678990"
                },
                 new WCFUser()
                {
                    Id = 3,
                    Name = "雅牛",
                    Sex = (int)WCFUserSex.Famale,
                    Age = 112,
                    Description = "123456678990"
                }
            };
        }


        public int Minus(int x, int y)
        {
            return x - y;
        }
    }
}
