using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, TeknikDestek")] // Sadece Admin ve Teknik Destek atama yapabilir
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetAssignmentsByTicketId(int ticketId)
        {
            var assignments = await _assignmentService.GetAssignmentsByTicketIdAsync(ticketId);
            return Ok(assignments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                await _assignmentService.AddAssignmentAsync(assignment);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
