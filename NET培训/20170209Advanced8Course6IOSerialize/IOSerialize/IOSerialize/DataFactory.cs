using IOSerialize.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    public class DataFactory
    {
        /// <summary>
        /// 妹子太稀少了。。
        /// </summary>
        /// <returns></returns>
        public static List<Programmer> BuildProgrammerList()
        {
            #region data prepare
            List<Programmer> list = new List<Programmer>();
            list.Add(new Programmer()
            {
                Id = 1,
                Description="高级班学员",
                Name = "SoWhat",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "day",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "领悟",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Sam",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "AlphaGo",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "折腾",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Me860",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "打兔子的猎人",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Nine",
                Sex = "女"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "望",
                Sex = "女"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "微笑刺客",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "waltz",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "爱在昨天",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "waltz",
                Sex = "男"
            });
            #endregion

            return list;
        }
    }
}
