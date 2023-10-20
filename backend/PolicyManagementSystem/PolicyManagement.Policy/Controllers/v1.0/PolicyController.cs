using Microsoft.AspNetCore.Mvc;
using Policy.Domain.Entities;
using Policy.Domain.Utilities;
using Policy.Service.Role;

namespace Policy.Api.Controllers.v1._0
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPolicyService _policyService;
        public PolicyController(ILogger<PolicyController> logger, IPolicyService policyService)
        {
            _logger = logger;
            _policyService = policyService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(PolicyEntity policy)
        {
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
                _logger.LogWarning(
                    LogEventsUtility.Error, ex, "ERROR WHEN REGISTER A POLICY: \n" + ex.Message);

                return BadRequest("ERROR WHEN REGISTER A POLICY: \n" +
                    "Please contact the server admin");
            }

        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
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
                _logger.LogWarning(
                    LogEventsUtility.Error, ex, "ERROR WHEN LIST A POLICY: \n" + ex.Message);

                return BadRequest("ERROR WHEN SEARCH A POLICY: \n" +
                    "Please contact the server admin");
            }
        }

        [HttpPost]
        [Route("searches")]
        public IActionResult Searches(dynamic filter)
        {
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
                _logger.LogWarning(
                    LogEventsUtility.Error, ex, "ERROR WHEN SEARCH A POLICY: \n" + ex.Message);

                return BadRequest("ERROR WHEN SEARCH A POLICY: \n" +
                    "Please contact the server admin");
            }
        }

    }
}
