using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Policy.Domain.Entities;
using Policy.Domain.Utilities;
using Policy.Service.Role;
using Serilog;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Policy.Api.Controllers.v1._0
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        private ProducerConfig config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(PolicyEntity policy)
        {
            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                _policyService.Register(policy);
                return Ok("Registration completed!");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("ERROR WHEN REGISTER A POLICY: \n" +
                    ex.Message);
            }
            catch (Exception ex)
            {
                var logMessage = "ERROR WHEN REGISTER A POLICY: \n" + ex.Message;
                Log.Error(ex, logMessage);
                producer.Produce("logstash-topic", new Message<Null, string> { Value = logMessage }); 
                return BadRequest("ERROR WHEN REGISTER A POLICY: \n" + "Please contact the server admin");
            }

        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var result = _policyService.GetAll();
                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return BadRequest("ERROR WHEN LIST A POLICY: \n"+
                    ex.Message);
            }
            catch (Exception ex)
            {
                var logMessage = "ERROR WHEN LIST A POLICY: \n" + ex.Message;
                Log.Error(ex, logMessage);
                producer.Produce("logstash-topic", new Message<Null, string> { Value = logMessage });
                return BadRequest("ERROR WHEN LIST A POLICY: \n" +
                    "Please contact the server admin");
            }
        }

        [HttpPost]
        [Route("searches")]
        public IActionResult Searches(dynamic filter)
        {
            var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var result = _policyService.Searches(filter);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("ERROR WHEN SEARCH A POLICY: \n"+
                    ex.Message);
            }
            catch (Exception ex)
            {
                var logMessage = "ERROR WHEN SEARCH A POLICY:\n" + ex.Message;
                Log.Error(ex, logMessage);
                producer.Produce("logstash-topic", new Message<Null, string> { Value = logMessage });
                return BadRequest("ERROR WHEN SEARCH A POLICY: \n" +
                    "Please contact the server admin");
            }
        }

    }
}
