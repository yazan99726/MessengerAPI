using Messenger.core.Data;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IFooterService footerService;

        public FooterController(IFooterService footerService)
        {
            this.footerService = footerService;
        }
        [HttpGet]
        public IActionResult GetFooter()
        {
            var result = footerService.GetFooter();
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateFooter")]
        public IActionResult UpdateFooter(Footer footer)
        {
            var result = footerService.UpdateFooter(footer);
            return Ok(result);
        }
        [HttpPost]
        [Route("upLoadImg")]
        public Footer UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Footer item = new Footer();
                item.logoImg = fileName;
                return item;
            }
            catch (Exception e)
            {
                return null;

            }

        }
    }
}
