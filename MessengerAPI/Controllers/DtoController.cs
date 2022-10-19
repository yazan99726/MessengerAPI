using Messenger.core.DTO;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtoController : ControllerBase
    {
        private readonly IDtoService dtoService;

        public DtoController(IDtoService dtoService)
        {
            this.dtoService = dtoService;
        }
        [HttpGet]
        [Route("GetAllNumberOfFriends/{userId}")]
        public IActionResult GetAllNumberOfFriends(int userId)
        {
            try
            {
                var result = dtoService.getAllNumberOfFriends(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("CreateGroupAndMember")]
        public async Task<IActionResult> CreateGroupAndMember([FromBody]CreateMessageGroupAndGroupMember groupAndGroupMember)
        {
            try
            {
                var result = await dtoService.createMessageGroupAndMember(groupAndGroupMember);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

       

    }
}
