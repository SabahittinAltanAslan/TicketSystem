using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, TeknikDestek, SubeMuduru")] // Şube Müdürü, Teknik Destek ve Admin Ticket loglarını görebilir
    public class StatusLogController : ControllerBase
    {
        private readonly IStatusLogService _statusLogService;

        public StatusLogController(IStatusLogService statusLogService)
        {
            _statusLogService = statusLogService;
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetStatusLogsByTicketId(int ticketId)
        {
            var logs = await _statusLogService.GetLogsByTicketIdAsync(ticketId);
            return Ok(logs);
        }
    }
}
