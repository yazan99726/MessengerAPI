using Messenger.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class ContactUsService : IContactUsService
    {

        private readonly IContactUsRepoisitory contactUsRepoisitory;

        public ContactUsService(IContactUsRepoisitory contactUsRepoisitory)
        {
            this.contactUsRepoisitory = contactUsRepoisitory;
        }

        public bool DeleteContact(int id)
        {
            return contactUsRepoisitory.DeleteContact(id);
        }

        public contactUs GetAboutById(int id)
        {
            return contactUsRepoisitory.GetAboutById(id);
        }

        public List<contactUs> GetContact()
        {
            return contactUsRepoisitory.GetContact();
        }

        public bool InsertContact(contactUs contact)
        {
            return contactUsRepoisitory.InsertContact(contact);
        }

        public bool UpdateContact(contactUs contact)
        {
            return contactUsRepoisitory.UpdateContact(contact);
        }
    }
}
