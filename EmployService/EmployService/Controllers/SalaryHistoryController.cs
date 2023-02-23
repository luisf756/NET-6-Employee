using EmployService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryHistoryController : ControllerBase
    {
        private readonly ISalaryHistoryRepository _historiRepository;

        public SalaryHistoryController(ISalaryHistoryRepository salaryHistoryRepository)
        {
            _historiRepository = salaryHistoryRepository;
        }

        [HttpGet]
        //[Route("unds")]
        public async Task<IActionResult> GetAllSalarys()
        {
            return Ok(await _historiRepository.GetAllSalarys());
        }

        [HttpPost("recalculate")]
        // [Route("recalculateSal")]
        public async Task<IActionResult> RecalculateSalaryEmployee(int id)
        {
            return Ok(await _historiRepository.GetHistoryId(id));
        }
    }
}
