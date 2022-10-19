using Messenger.core;
using Messenger.core.Data;
using Messenger.core.DTO;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly IUserService userService;
        public LoginController(ILoginService loginService, IUserService userService)
        {
            this.loginService = loginService;
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult authentication([FromBody] Login login)
        {
            var RESULT = loginService.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }
        }

        [HttpPut]
        [Route("restPassword/{loginId}")]
        public IActionResult restPassword([FromBody] Login login)
        {
            return Ok(this.loginService.restPassword(login));
        }

        [HttpPost]
        [Route("getLogByEmail")]
        public IActionResult getLogByEmail([FromBody] Login login)
        {
            return Ok(this.loginService.getLogByEmail(login.Email));
        }

        [HttpGet]
        [Route("UpdateVerificationCode")]
        public IActionResult UpdateVerificationCode()
        {

            return Ok(this.userService.reSendVerificationCode(Global.userLog));
        }

        [HttpPost]
        [Route("logOut/{userId}")]
        public IActionResult logOut(int userId)
        {
            var result = this.userService.GetUserById(userId);
            result.IsActive = 0;
            return Ok(this.userService.activationChange(result));
        }

        [HttpPost]
        [Route("ChangeCurrentPassword")]
        public IActionResult ChangeCurrentPassword([FromBody] UserChangeCurrPass userChangeCurrPass)
        {
            
            return Ok(this.loginService.ChangeCurrentPassword(userChangeCurrPass));
        }
    }
}
