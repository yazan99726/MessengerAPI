using Messenger.core.Data;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }
        [HttpGet]
        [Route("GetContact")]
        public IActionResult GetContact()
        {
            var result = contactUsService.GetContact();
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateContact")]
        public IActionResult UpdateContact(contactUs contact)
        {
            var result = contactUsService.UpdateContact(contact);
            return Ok(result);
        }
        [HttpPost]
        [Route("InsertContact")]
        public IActionResult InsertContact(contactUs contact)
        {
            var result = contactUsService.InsertContact(contact);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var result = contactUsService.DeleteContact(id);
            return Ok(result);
        }
    }
}
