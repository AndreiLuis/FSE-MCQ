using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using User.Domain.Entities;
using User.Service.Role;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Api.Controllers.v1._0
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        private ProducerConfig config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        public CustomerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }


        // POST api/<CustomerController>
        [HttpPost]
        [Route("register")]
        public IActionResult Register(CostumerEntity costumer)
        {
            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                _costumerService.Register(costumer);
                return Ok("Registration completed!");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("ERROR WHEN REGISTER THE COSTUMER: \n" +
                    ex.Message);
            }
            catch (Exception ex)
            {
                var logMessage = "ERROR WHEN REGISTER THE COSTUMER: \n" + ex.Message;
                Log.Error(ex, logMessage);
                producer.Produce("logstash-topic", new Message<Null, string> { Value = logMessage });
                return BadRequest("ERROR WHEN REGISTER THE COSTUMER: \n" +
                    "Please contact the server admin");
            }
        }
    }
}
