using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface IFooterService
    {
        public bool InsertFooter(Footer footer);
        public List<Footer> GetFooter();
        public bool UpdateFooter(Footer footer);
        public bool DeleteFooter(int id);
        public Footer GetFooterById(int id);
    }
}
