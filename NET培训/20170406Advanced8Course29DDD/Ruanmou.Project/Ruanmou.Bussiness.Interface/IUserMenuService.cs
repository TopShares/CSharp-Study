﻿using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Interface
{
    public interface IUserMenuService : IBaseService
    {
        void UserLastLogin(User user);
    }
}
