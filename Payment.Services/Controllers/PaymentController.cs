using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Payment.Services.Services;

namespace Payment.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/Payment")]
    [EnableCors("AllowAllHeaders")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }
        // GET: api/Payment
        [HttpGet]
        public IEnumerable<Models.Payment> Get()
        {
            _logger.Log(LogLevel.Information, "Request recieved to fetch data for all the records", null);
            return _paymentService.GetAllPayments();
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "Get")]
        public Models.Payment Get(int id)
        {
            _logger.Log(LogLevel.Information, "Request recieved to fetch data for Record " + id, null);
            return _paymentService.GetPaymentInfo(id);
        }

        // POST: api/Payment
        [HttpPost]
        public void Post([FromBody]Models.Payment paymentRecord)
        {
            _logger.Log(LogLevel.Information, "Request recieved to create a new payment Record", null);

            var record = JsonConvert.SerializeObject(paymentRecord);
            System.IO.File.WriteAllText(Path.Combine(Path.GetTempPath(), "log_" + Guid.NewGuid() + ".txt"), record);

            var Id = _paymentService.CreatePayment(paymentRecord);
            _logger.Log(LogLevel.Information, "Creation of new payment Record is completed", null);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            _logger.Log(LogLevel.Information, "Request Recieved to update" + id.ToString(), null);
            var paymentInfo = _paymentService.GetPaymentInfo(id);
            paymentInfo.Amount = 123.0012m;
            _paymentService.UpdatePayment(paymentInfo);
           _logger.Log(LogLevel.Information, "Updation of  payment Record is completed", null);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.Log(LogLevel.Information, "Request recieved to delete " +  id.ToString(), null);
            _paymentService.DeletePayment(id);
            _logger.Log(LogLevel.Information, "Deletion of  payment Record is completed", null);
        }
    }
}
