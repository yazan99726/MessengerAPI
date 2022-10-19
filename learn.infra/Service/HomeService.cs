using Messenger.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepoisitory homeRepoisitory;
        public HomeService(IHomeRepoisitory homeRepoisitory)
        {
            this.homeRepoisitory = homeRepoisitory;
        }
        public bool DeleteHome(int id)
        {
            return homeRepoisitory.DeleteHome(id);
        }

        public List<Home> GetHome()
        {
            return homeRepoisitory.GetHome();
        }

        public Home GetHomeById(int id)
        {
            return homeRepoisitory.GetHomeById(id);
        }

        public bool InsertHome(Home home)
        {
            return homeRepoisitory.InsertHome(home);
        }

        public bool UpdateHome(Home home)
        {
            return homeRepoisitory.UpdateHome(home);
        }
    }
    //
}
