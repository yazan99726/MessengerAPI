using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet]
        [Route("GetAllPayment")]
        public IActionResult GetAllPayment()
        {
            try
            {
                var result = paymentService.GetAllPayments();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetPaymentById/{id}")]
        public IActionResult GetPaymentById(int id)
        {
            try
            {
                var result = paymentService.GetPaymentsById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("AddPayment")]
        public IActionResult AddPayment([FromBody] Payments payment)
        {
            try
            {
                paymentService.AddPayments(payment);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("UpDatePayment")]
        public IActionResult UpDatePayment([FromBody] Payments payment)
        {
            try
            {
                paymentService.UpDatePayments(payment);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeletePayment")]
        public IActionResult DeletePayment([FromBody] Payments payment)
        {
            try
            {
                paymentService.DeletePayments(payment.Paymentid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("GetPaymentsByUserId/{userId}")]
        public async Task<IActionResult> GetPaymentsByUserId(int userId)
        {
            try
            {
                var result = await paymentService.GetPaymentsByUserId(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("GetPaymentsByDetails")]
        public IActionResult GetPaymentsByDetails()
        {
            var result =  paymentService.GetPaymentsByDetails();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetRevenue")]
        public IActionResult GetRevenue()
        {
            var result =  paymentService.GetRevenue();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetRevenueByMonth")]
        public IActionResult GetRevenueByMonth()
        {
            var result = paymentService.GetRevenueByMonth();
            return Ok(result);
        }
    }
}
