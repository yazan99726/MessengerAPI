using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface IContactUsService
    {
        public bool InsertContact(contactUs contact);
        public List<contactUs> GetContact();
        public bool UpdateContact(contactUs contact);
        public bool DeleteContact(int id);
        public contactUs GetAboutById(int id);
    }
}
