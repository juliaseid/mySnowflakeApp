using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using mySnowflakeApp.Models;
using mySnowflakeApp.Services;

namespace mySnowflakeApp.Controllers
{
    [ApiController]
    [Produces("text/json")]
    [Route("[controller]")]
    public class mySnowflakeController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public mySnowflakeController(CustomerService customerService) =>
          _customerService = customerService;

        [HttpGet]
        [EnableCors]
        [Route("/demographics")]
        public ActionResult<string> GetMaritalPercentages()
        {
          var customers = _customerService.GetCustomers();
          var data = Demographics.Create(customers);
          string percentages = Demographics.GetMaritalData(data);
          return percentages;
        }
    }
}
