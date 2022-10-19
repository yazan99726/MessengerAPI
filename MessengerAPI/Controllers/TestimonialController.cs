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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            this.TestimonialService = TestimonialService;
        }
        [HttpGet]
        [Route("GetAllTests")]
        public List<testimonial> GetAllTests()
        {
            return TestimonialService.GetAllTests();
        }
        [HttpPut]
        [Route("AcceptTest")]
        public IActionResult AcceptTest(testimonial test)
        {
            try
            {
                var result = TestimonialService.AcceptTest(test);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("RejectTest")]
        public IActionResult RejectTest(testimonial test)
        {
            try
            {
                var result = TestimonialService.RejectTest(test);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("GetUserById")]
        public List<testimonial> GetUserById(testimonial test)
        {
            return TestimonialService.GetUserById(test.userId);

        }
        [HttpPost]
        [Route("Getpublishdate")]
        public IActionResult Getpublishdate(GetTestimonialByUserName test)
        {
            return Ok(TestimonialService.Getpublishdate(test));
        }
        [HttpGet]
        [Route("GetTestimonialShow")]
        public IActionResult GetTestimonialShow()
        {
            return Ok(TestimonialService.GetTestimonialShow());
        }
        [HttpGet]
        [Route("GetTestimonialByUserName")]
        public IActionResult  GetTestimonialByUserName()
        {
            return Ok(TestimonialService.GetTestimonialByUserName());
        }



        [HttpPost]
        public IActionResult InsertTest([FromBody] testimonial test)
        {
            return Ok(TestimonialService.InsertTest(test));
        }
    }
}
