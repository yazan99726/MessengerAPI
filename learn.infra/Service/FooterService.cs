using Messenger.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using Messenger.infra.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class FooterService: IFooterService
    {
        private readonly IFooterRepoisitory footerRepository;

        public FooterService(IFooterRepoisitory footerRepository)
        {
            this.footerRepository = footerRepository;
        }

        public bool DeleteFooter(int id)
        {
            return footerRepository.DeleteFooter(id);
        }

        public List<Footer> GetFooter()
        {
            return footerRepository.GetFooter();
        }

        public Footer GetFooterById(int id)
        {
            return footerRepository.GetFooterById(id);
        }

        public bool InsertFooter(Footer footer)
        {
            return footerRepository.InsertFooter(footer);
        }

        public bool UpdateFooter(Footer footer)
        {
            return footerRepository.UpdateFooter(footer);
        }
    }
}
