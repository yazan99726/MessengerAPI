using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }
        [HttpGet]
        [Route("GetAllServices")]
        public IActionResult GetAllServices()
        {
            try
            {
                var result = servicesService.GetAllServices();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetServiseById/{id}")]
        public IActionResult GetServiseById(int id)
        {
            try
            {
                var result = servicesService.GetServiceById(id);
                return Ok(result);
            }
            catch (Exception e) 
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("AddServices")]
        public IActionResult AddServices([FromBody] Services services)
        {
            try
            {
                servicesService.AddServices(services);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("UpDateServices")]
        public IActionResult UpDateServices([FromBody] Services services)
        {
            try
            {
                servicesService.UpDateServices(services);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteServices")]
        public IActionResult DeleteServices([FromBody] Services services)
        {
            try
            {
                servicesService.DeleteServices(services.Serviceid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("getByServicesName/{names}")]
        public IActionResult getByServicesName(string names)
        {
            try
            {
                var result = servicesService.getByServicesName(names);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
