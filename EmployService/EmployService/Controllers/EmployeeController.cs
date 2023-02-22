using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EmployService.Data.Repositories;
using EmployService.Model;

namespace EmployService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployRepository _employRepository;

        public EmployeeController(IEmployRepository employeeRepository)
        {
            _employRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employRepository.GetAllEmployees());  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _employRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _employRepository.InsertEmployee(employee);

            return Created("created", created);

        }
        // se cambian para mira
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             await _employRepository.UpdateEmployee(employee);

            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employRepository.DeleteEmployee(new Employee { Emp_Id = id });
            
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> RecalculateSalaryEmployee(int id)
        {
            return Ok(await _employRepository.RecalculateSalaryEmployee(id));
        }

        //[HttpGet]
        //public async Task<IActionResult> Export_DataEmployees()
        //{
        //    //return Ok(await _employRepository.Export_DataEmployees());
        //}

    }
}
