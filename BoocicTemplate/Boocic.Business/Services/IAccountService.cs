﻿using Boocic.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.Services
{
    public interface IAccountService
    {
        Task Login(AdminLoginViewModel adminLoginViewModel);
        Task Logout();
    }
}
