using Microsoft.AspNetCore.Mvc;
using Policy.Domain.Utilities;
using User.Domain.Entities;
using User.Service.Role;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Api.Controllers.v1._0
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICostumerService _costumerService;

        public CustomerController(ILogger<CustomerController> logger, ICostumerService costumerService)
        {
            _logger = logger;
            _costumerService = costumerService;
        }


        // POST api/<CustomerController>
        [HttpPost]
        [Route("register")]
        public IActionResult Register(CostumerEntity costumer)
        {
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
                _logger.LogWarning(
                    LogEventsUtility.Error, ex, "ERROR WHEN REGISTER THE COSTUMER: \n" + ex.Message);

                return BadRequest("ERROR WHEN REGISTER THE COSTUMER: \n" +
                    "Please contact the server admin");
            }
        }
    }
}
