using Budgets.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Budgets.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly ILogger<BudgetController> _logger;

        public BudgetController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBudget")]
        public Budget Get()
        {
            return new Budget(1, "Test", "EUR", "dd/MM/yyyy");
        }
    }
}