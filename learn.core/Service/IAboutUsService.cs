using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface IAboutUsService
    {
        public bool InsertAbout(aboutUs about);
        public List<aboutUs> GetAbout();
        public bool UpdateAbout(aboutUs about);
        public bool DeleteAbout(int id);
        public aboutUs GetAboutById(int id);
    }
}
