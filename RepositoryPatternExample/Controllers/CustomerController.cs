using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerRepository.GetAllAsync());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _customerRepository.GetByIdAsync(id));
        }


        // GET api/<CustomerController>/5
        [Route("GetCustomersWithIdLessThanTwenty")]
        [HttpGet]
        public async Task<IActionResult> GetCustomersWithIdLessThanTwenty()
        {
            return Ok(await _customerRepository.GetCustomersWithIdLessThanTwenty());
        }
    }
}
