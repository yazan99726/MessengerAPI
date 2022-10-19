using learn.core.Data;
using learn.core.Service;
using learn.infra.Service;
using Messenger.core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageservice Messageservice  ;
        public MessageController(IMessageservice Messageservice)
        {
            this.Messageservice = Messageservice;
        }
        [HttpGet]
        [Route("GetAllMessage")]
        public IActionResult GetAllMessage()
        {
            var result = Messageservice.GetAllMessage();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var result = Messageservice.DeleteMessage(id);
            return Ok();

        }
        [HttpPost]
        [Route("CreateMessage")]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            //message.MessageDate = DateTime.UtcNow;
            
            var result = Messageservice.CreateMessage(message);
            return Ok();
        }

        [HttpPut]
        [Route("UpDateMessage")]
        public IActionResult UpDateMessage([FromBody] Message cc)
        {
            var result = Messageservice.UpDateMessage(cc);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMessageById/{id}")]
        public IActionResult GetMessageById(int id)
        {
            var result = Messageservice.GetMessageById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMessageForMessageGroup/{messageGroup_Id}")]
        public async Task<IActionResult> GetMessageForMessageGroup(int messageGroup_Id)
        {
            try
            {
                var result = await Messageservice.GetAllMessageForMessageGroup(messageGroup_Id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("SearchMessageBetweenDate")]
        public async Task<IActionResult> SearchMessageBetweenDate([FromBody] SearchMessageBetweenDate searchMessage)
        {
            try
            {
                var result = await Messageservice.SearchMessageBetweenTwoDate(searchMessage);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("uploadImageMessage")]
        public Message uploadImageMessage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName="";
                //foreach (var c in file)
                //{
                     fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                //}
                
                Message item = new Message();
                item.Text = fileName;
                
                return item;
            }
            catch (Exception e)
            {
                return new Message();
            }
        }

    }
}
