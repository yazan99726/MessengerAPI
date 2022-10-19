using Messenger.core.Data;
using Messenger.core.DTO;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserLogDTO userlog)
        {
            var result = userService.InsertUser(userlog);

            return Ok(result);
        }

        [HttpDelete("DeleteUser/{UserId}")]
        public IActionResult DeleteCourse(int UserId)
        {
            return Ok(userService.DeleteUser(UserId));
        }
        [HttpGet]
        public List<Userr> GetAllUsers()
        {
            return userService.GetAllUsers();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public bool UpdateUser([FromBody] Userr user)
        {
            return userService.UpdateUser(user);
        }

        [HttpGet]
        [Route("GetUserById/{userId}")]
        public Userr GetUserById(int userId)
        {
            return userService.GetUserById(userId);
        }
        
        [HttpGet]
        [Route("GetUserByUserName/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                var result = userService.GetUserByUserName(userName);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("ConfirmEmail/{code}")]
        public IActionResult confirmEmail(string code)
        {
            return Ok(userService.confirmEmail(code));
        }


        [HttpPost]
        [Route("upLoadImg")]
        public Userr UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Userr item = new Userr();
                item.ProFileImg = fileName;
                return item;
            }
            catch (Exception e)
            {
                return null;

            }

        }

        [HttpPost]
        [Route("uploadImage")]
        public Userr uploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Userr item = new Userr();
                item.ProFileImg = fileName;
                return item;
            }
            catch (Exception e)
            {
                return new Userr();
            }
        }

        [HttpPost]
        [Route("IsBlocked")]
        public IActionResult IsBlocked([FromBody] Userr user)
        {
            try
            {
                var result = userService.IsBlocked(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("UnBlocked")]
        public IActionResult UnBlock(Userr user)
        {
            try
            {
                var result = userService.UnBlock(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }
        [HttpPost]
        [Route("uploadImageAdmin")]
        public Userr uploadImageAdmin()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\yazan\\OneDrive\\سطح المكتب\\New folder (2)\\MessengerAppUI\\src\\assets\\Img", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Userr item = new Userr();
                item.ProFileImg = fileName;
                return item;
            }
            catch (Exception e)
            {
                return new Userr();
            }
        }
        [HttpPut]
        [Route("ActivationChange")]
        public IActionResult ActivationChange([FromBody] Userr user)
        {
            try
            {
                this.userService.activationChange(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
