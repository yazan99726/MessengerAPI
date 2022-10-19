﻿using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface IHomeRepoisitory
    {
        public bool InsertHome(Home home);
        public List<Home> GetHome();
        public bool UpdateHome(Home home);
        public bool DeleteHome(int id);
        public Home GetHomeById(int id);
    }
}
