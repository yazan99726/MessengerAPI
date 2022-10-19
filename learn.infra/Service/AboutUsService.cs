using Messenger.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class AboutUsService : IAboutUsService
    {

        private readonly IAboutUsRepoisitory aboutUsRepoisitory;

        public AboutUsService(IAboutUsRepoisitory aboutUsRepoisitory)
        {
            this.aboutUsRepoisitory = aboutUsRepoisitory;
        }

        public bool DeleteAbout(int id)
        {
            return aboutUsRepoisitory.DeleteAbout(id);
        }

        public List<aboutUs> GetAbout()
        {
            return aboutUsRepoisitory.GetAbout();
        }

        public aboutUs GetAboutById(int id)
        {
            return aboutUsRepoisitory.GetAboutById(id);
        }

        public bool InsertAbout(aboutUs about)
        {
            return aboutUsRepoisitory.InsertAbout(about);
        }

        public bool UpdateAbout(aboutUs about)
        {
            return aboutUsRepoisitory.UpdateAbout(about);
        }
    }
}
