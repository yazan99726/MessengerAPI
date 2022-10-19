using learn.core.Data;
using learn.core.Service;
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
    public class MessageGroupController : ControllerBase
    {
        private readonly IMessageGroupservice MessageGroupservice ;
        public MessageGroupController(IMessageGroupservice MessageGroupservice)
        {
            this.MessageGroupservice = MessageGroupservice;
        }
        [HttpGet]
        [Route("GetAllMessageGroup")]
        public IActionResult GetAllMessageGroup()
        {
            var result = MessageGroupservice.GetAllMessageGroup();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteMessageGroup/{id}")]
        public IActionResult DeleteMessageGroup(int id)
        {
            var result = MessageGroupservice.DeleteMessageGroup(id);
            return Ok();

        }
        [HttpPost]
        [Route("CreateMessageGroup")]
        public IActionResult MessageGroup([FromBody] MessageGroup cc)
        {
            var result = MessageGroupservice.CreateMessageGroup(cc);
            return Ok();
        }

        [HttpPut]
        [Route("UpDateMessageGroup")]
        public IActionResult UpDateMessageGroup([FromBody] MessageGroup cc)
        {
            var result = MessageGroupservice.UpDateMessageGroup(cc);
            return Ok();
        }
        [HttpGet]
        [Route("GetMessageGroupById/{id}")]
        public IActionResult GetMessageGroupById(int id)
        {
            var result = MessageGroupservice.GetMessageGroupById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetFullMessageGroup/{id}")]
        public async Task<IActionResult> GetFullMessageGroup(int id)
        {
            try
            {
                var result = await MessageGroupservice.GetMessageGroupForUser(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpPost]
        [Route("uploadImage")]
        public MessageGroup uploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString()+"_"+ file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                MessageGroup item = new MessageGroup();
                item.GroupImg = fileName;
                return item;
            }
            catch (Exception e)
            {
                return new MessageGroup();
            }
        }
    }
}
