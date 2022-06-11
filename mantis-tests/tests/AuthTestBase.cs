﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void PerformLogin()
        {
            app.Auth.Login(new AccountData()
            {
                Name = "administrator",
                Password = "root"
            });
        }

        [TearDown]
        public void PerformLogout()
        {
            app.Auth.Logout();
        }
    }
}