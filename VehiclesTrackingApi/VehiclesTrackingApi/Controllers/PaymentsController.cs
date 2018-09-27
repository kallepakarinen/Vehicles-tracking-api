using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTrackingApi.Services;
using VehiclesTrackingApi.Models;

namespace VehiclesTrackingApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET api/payments
        [HttpGet]
        public IActionResult Get()
        {
            List<Payment> payments = _paymentService.GetPayments();
            return new JsonResult(payments);
        }
        // GET api/payments/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Payment payment = _paymentService.GetPaymentById(id);
            return new JsonResult(payment);
        }
        // Post api/payments
        [HttpPost]
        public IActionResult Create([FromBody] Payment payment)
        {
            Payment createPayment = _paymentService.CreatePayment(payment);
            return new JsonResult(createPayment);
        }
        // Put api/payments
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Payment payment)
        {
            Payment updatePayment = _paymentService.UpdatePayment(id, payment);
            return new JsonResult(updatePayment);
        }
        // Delete api/payments/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _paymentService.DeletePayment(id);
            return new OkResult();
        }

        [HttpGet("report/{year}")]
        public IActionResult GetReport(int year)
        {
            List<PaymentsReport> payments = _paymentService.GetReport(year);
            return new JsonResult(payments);
        }
    }
}
