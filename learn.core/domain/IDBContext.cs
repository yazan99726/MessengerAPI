﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace learn.core.domain
{
    public interface IDBContext
    {
        public DbConnection dbConnection { get; }
    }
}
