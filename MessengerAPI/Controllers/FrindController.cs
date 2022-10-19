using learn.core.Data;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrindController : ControllerBase
    {
        private readonly IFrindService frindService;

        public FrindController(IFrindService frindService)
        {
            this.frindService = frindService;
        }
        [HttpGet]
        [Route("GetFrinds/{userId}")]
        public async Task<IActionResult> GetFrinds(int userId)
        {
            try
            {
                var result = await frindService.GetAllFrinds(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetFrindById")]
        public IActionResult GetFrindById([FromBody] Frinds frind)
        {
            try
            {
                var result = frindService.GetFrindById((int)frind.User_Id, frind.Userreceiveid);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("AddFrind")]
        public IActionResult AddFrind([FromBody] Frinds frind)
        {
            try
            {
                frind.Adddate = DateTime.Now;
                frindService.AddFrind(frind);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("UpDateFrind")]
        public IActionResult UpDateFrind([FromBody] Frinds frind)
        {
            try
            {
                frindService.UpdateFrind(frind);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteFrind/{id}")]
        public IActionResult DeleteFrind(int id)
        {
            try
            {
                frindService.DeleteFrind(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("confirmFriend/{id}")]
        public IActionResult confirmFriend(int id)
        {
            try
            {
                frindService.confirmFriend(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("BlockFriend/{id}")]
        public IActionResult BlockFriend(int id)
        {
            try
            {
                frindService.BlockFriend(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
