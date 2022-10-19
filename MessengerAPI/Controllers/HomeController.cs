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
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [HttpGet]
        [Route("GetHome")]
        public IActionResult GetHome()
        {
            var result = homeService.GetHome();
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateHome")]
        public IActionResult UpdateHome(Home home)
        {
            var result = homeService.UpdateHome(home);
            return Ok(result);
        }
        [HttpPost]
        [Route("upLoadImg/{type}")]
        public Home UploadImage(string type)
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

                Home item = new Home();
                switch (type)
                {
                    case "1":
                        item.lapImg = fileName;
                        break;
                    case "2":
                        item.chatAppImg = fileName;
                        break;
                    case "3":
                        item.mobileImg = fileName;
                        break;
                    case "4":
                        item.QRcodeImg = fileName;
                        break;
                    case "5":
                        item.userCustamizerImg = fileName;
                        break;
                    case "6":
                        item.RTLImg = fileName;
                        break;
                    case "7":
                        item.FilesImg = fileName;
                        break;
                    case "8":
                        item.futcherImg = fileName;
                        break;
                    case "9":
                        item.NoteImg = fileName;
                        break;
                    case "10":
                        item.RemiderImg = fileName;
                        break;
                    case "11":
                        item.someFutchersImg = fileName;
                        break;
                    case "12":
                        item.DarkLightImg = fileName;
                        break;
                    case "13":
                        item.audioImg = fileName;
                        break;
                    case "14":
                        item.SendStickerImg = fileName;
                        break;
                    case "15":
                        item.ChatHistoryContactImg = fileName;
                        break;
                    case "16":
                        item.ViewStatusImg = fileName;
                        break;
                }
                return item;
            }
            catch (Exception e)
            {
                return null;

            }

        }
    }
}
